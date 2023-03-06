using MongoDB.Bson;
using System.Linq.Expressions;

namespace PortfolioServices.Context.Interfaces;

public interface IGenericDAL<TDocument>
{
    IQueryable<TDocument> AsQueryable();

    IEnumerable<TDocument> FindAll();

    Task<IEnumerable<TDocument>> FindAllAsync();

    IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression);

    IEnumerable<TProjected> FilterBy<TProjected>(
        Expression<Func<TDocument, bool>> filterExpression,
        Expression<Func<TDocument, TProjected>> projectionExpression);

    TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression);

    Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression);

    TDocument FindById(ObjectId id);

    Task<TDocument> FindByIdAsync(ObjectId id);

    void Create(TDocument document);

    Task CreateAsync(TDocument document);

    void Create(ICollection<TDocument> documents);

    Task CreateAsync(ICollection<TDocument> documents);

    void Update(TDocument document);

    Task UpdateAsync(TDocument document);

    void Delete(Expression<Func<TDocument, bool>> filterExpression);

    Task DeleteAsync(Expression<Func<TDocument, bool>> filterExpression);

    void DeleteById(ObjectId id);

    Task DeleteByIdAsync(ObjectId id);

    void DeleteMany(Expression<Func<TDocument, bool>> filterExpression);

    Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression);
}
