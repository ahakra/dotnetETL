namespace DataSource.Entities;
using Microsoft.Extensions.Options;

public class DatasourceDatabaseSettings {
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string DataSourceCollectionName { get; set; } = null!;
}