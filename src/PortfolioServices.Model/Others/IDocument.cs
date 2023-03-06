using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PortfolioServices.Model.Others;

public class IDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public ObjectId _id { get; set; }
}
