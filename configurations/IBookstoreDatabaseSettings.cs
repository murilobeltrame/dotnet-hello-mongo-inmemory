namespace Configurations
{
    public interface IBookstoreDatabaseSettings
    {
        string BookstoreCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}