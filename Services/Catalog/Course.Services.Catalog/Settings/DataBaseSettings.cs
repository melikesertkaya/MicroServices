namespace Course.Services.Catalog.Settings
{
    public class DataBaseSettings : IDatabaseSettings
    {
        public string CourseCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
    }
}
