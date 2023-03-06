using PortfolioServices.Model.Others;

namespace PortfolioServices.Model;

[BsonCollection("Home")]
public class Home : IDocument
{
    public DateTimeOffset? CreatedAt {  get; set; }

    public DateTimeOffset? ModifiedAt { get; set; }

    public string Type { get; set; }
}
