namespace Commander.Models
{
    public class CommanderApiSettings : ICommanderApiSettings
    {
        public string CommandsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICommanderApiSettings
    {
        string CommandsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}