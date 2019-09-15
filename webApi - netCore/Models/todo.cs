using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksApi.Models
{
     public class TodoDatabaseSettings : ITodoDatabaseSettings
    {
        public string TodosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ITodoDatabaseSettings
    {
        string TodosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string[] doo { get; set; }
        public string[] doing { get; set; }
        public string[] done { get; set; }
    }
}