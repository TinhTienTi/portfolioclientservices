using MongoDB.Bson;
using PortfolioServices.Model.Others;

namespace PortfolioServices.Model;

[BsonCollection("Language")]
public class Language : IDocument
{
    public DateTimeOffset? CreatedAt { get; set; }

    public DateTimeOffset? ModifiedAt { get; set; }

    public ObjectId Key { get; set; }

    public string Value { get; set; }

    public string Object { get; set; }

    public string Code { get; set; }
}
