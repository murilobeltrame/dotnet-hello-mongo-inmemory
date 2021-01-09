namespace Configurations
{
    public class BookstoreDatabaseSettings: IBookstoreDatabaseSettings
    {
        public string BookstoreCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}