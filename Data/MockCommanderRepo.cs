using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public Command CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id="0", HowTo="Boil an egg", Line="Boil water first", Platform="Kettle"},
                new Command{Id="1", HowTo="Cut the bread", Line="Get a knife", Platform="Chopping board"},
                new Command{Id="2", HowTo="Make Tea", Line="Place teabag", Platform="Kettle & Cup"},
            };

            return commands;
        }

        public Command GetCommandById(string id)
        {
            return new Command{
                Id="0",
                HowTo="Boil an egg",
                Line="Boil water first",
                Platform="Kettle"
            };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(string id, Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}