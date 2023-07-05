
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiMongoDB.Models
{
    [BsonIgnoreExtraElements]
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("firstname")]
        public string FirstName { get; set; } = "Student First Name";

        [BsonElement("lastname")]
        public string LastName { get; set; } = "Student Last Name";

        [BsonElement("department")]
        public string Department { get; set; } = "Department";

        [BsonElement("class")]
        public string ClassName { get; set; } = "Class Name";

        [BsonElement("gender")]
        public byte Gender { get; set; } = 1;

        [BsonElement("birthday")]
        public DateTime DateOfBirth { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("graduated")]
        public bool IsGraduated { get; set; }
    }
}
