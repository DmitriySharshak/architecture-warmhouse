using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.PostgreSQL;
using LinqToDB.Mapping;

namespace Temperature
{
    public class SmartHomeDb
    {
        private readonly DataConnection _connection;

        public SmartHomeDb(string connectionString)
        {
            _connection = new DataConnection(PostgreSQLTools.GetDataProvider(PostgreSQLVersion.v93), connectionString);
        }

        public ITable<T> GetTable<T>() where T : class
        {
            return _connection.GetTable<T>();
        }

        public ITable<Sensor> Sensors { get { return GetTable<Sensor>();  } } 

    }


    [Table("sensors")] 
    public class Sensor
    {
        [PrimaryKey, Identity] 
        [Column("id")]
        public int Id { get; set; }

        [Column("name"), NotNull] 
        public string Name { get; set; }

        [Column("type"), NotNull]
        public string Type { get; set; }

        [Column("location"), NotNull]
        public string Location { get; set; }

        [Column("unit"), NotNull]
        public string Unit { get; set; }

        [Column("status"), NotNull]
        public string Status { get; set; }

        [Column("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
