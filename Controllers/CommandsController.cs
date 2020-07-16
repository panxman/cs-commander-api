using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/commands
        [HttpGet()]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commands = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        // GET api/commands/{id}
        [HttpGet("{id:length(24)}", Name = "GetCommand")]
        public ActionResult<CommandReadDto> GetCommandbyId(string id)
        {
            var command = _repository.GetCommandById(id);

            if (command == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        // POST api/commands
        [HttpPost()]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            var command = _repository.CreateCommand(commandModel);

            return CreatedAtRoute("GetCommand", new { id = command.Id.ToString() }, _mapper.Map<CommandReadDto>(command));
        }

        // PUT api/commands/{id}
        [HttpPut("{id:length(24)}")]
        public ActionResult UpdateCommand(string id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);

            if (commandModelFromRepo == null) {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommand(id, commandModelFromRepo);

            return NoContent();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id:length(24)}")]
        public ActionResult PartialUpdateCommand(string id, JsonPatchDocument<CommandUpdateDto> patchDocument)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);

            if (commandModelFromRepo == null) {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDocument.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch)) {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateCommand(id, commandModelFromRepo);

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id:length(24)}")]
        public ActionResult DeleteCommand(string id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);

            if (commandModelFromRepo == null) {
                return NotFound();
            }

            _repository.DeleteCommand(commandModelFromRepo);

            return NoContent();
        }
    }
}
