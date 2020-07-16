using System;
using System.Collections.Generic;
using Commander.Models;
using Commander.Services;

namespace Commander.Data
{
    public class MongoCommanderRepo : ICommanderRepo
    {
        private readonly CommandService _service;
        public MongoCommanderRepo(CommandService service)
        {
            _service = service;
        }

        public Command CreateCommand(Command command)
        {
            if (command == null) {
                throw new ArgumentNullException(nameof(command));
            }

            return _service.Create(command);
        }

        public void DeleteCommand(Command command)
        {
            if (command == null) {
                throw new ArgumentNullException(nameof(command));
            }

            _service.Remove(command);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _service.Get();
        }

        public Command GetCommandById(string id)
        {
            return _service.Get(id);
        }

        public void UpdateCommand(string id, Command command)
        {
            if (command == null) {
                throw new ArgumentNullException(nameof(command));
            }

            _service.Update(id, command);
        }
    }
}
