using System.Collections.Generic;
using Commander.Models;
using MongoDB.Driver;

namespace Commander.Services
{
    public class CommandService
    {
        private readonly IMongoCollection<Command> _commands;

        public CommandService(ICommanderApiSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _commands = database.GetCollection<Command>(settings.CommandsCollectionName);
        }

        public List<Command> Get() =>
            _commands.Find(command => true).ToList();

        public Command Get(string id) =>
            _commands.Find<Command>(command => command.Id == id).FirstOrDefault();

        public Command Create(Command command)
        {
            _commands.InsertOne(command);

            return command;
        }

        public void Update(string id, Command commandIn)
        {
            _commands.ReplaceOne(command => command.Id == id, commandIn);
        }

        public void Remove(Command commandIn)
        {
            _commands.DeleteOne(command => command.Id == commandIn.Id);
        }

        public void Remove(string id)
        {
            _commands.DeleteOne(command => command.Id == id);
        }
    }
}