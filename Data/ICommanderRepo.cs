using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data 
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(string id);
        Command CreateCommand(Command command);
        void UpdateCommand(string id, Command command);
        void DeleteCommand(Command command);
    }
}