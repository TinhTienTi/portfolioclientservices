using MongoDB.Bson;
using MongoDB.Driver;
using PortfolioServices.Context.Interfaces;
using PortfolioServices.Model.Others;
using System.Linq.Expressions;

namespace PortfolioServices.Context;

public class GenericDAL<TDocument> : IGenericDAL<TDocument>
  where TDocument : IDocument
{
    private readonly IMongoCollection<TDocument> _collection;

    public GenericDAL(IMongoDbSettings settings)
    {
        var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);

        _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
    }

    public virtual IQueryable<TDocument> AsQueryable()
    {
        return _collection.AsQueryable();
    }

    public virtual IEnumerable<TDocument> FindAll()
    {
        return _collection.FindAsync(x => 1 == 1).Result.ToEnumerable();
    }

    public virtual async Task<IEnumerable<TDocument>> FindAllAsync()
    {
        return (await _collection.FindAsync(x => 1 == 1)).ToEnumerable();
    }

    public virtual IEnumerable<TDocument> FilterBy(
        Expression<Func<TDocument, bool>> filterExpression)
    {
        return _collection.Find(filterExpression).ToEnumerable();
    }

    public virtual IEnumerable<TProjected> FilterBy<TProjected>(
        Expression<Func<TDocument, bool>> filterExpression,
        Expression<Func<TDocument, TProjected>> projectionExpression)
    {
        return _collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
    }

    public virtual TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
    {
        return _collection.Find(filterExpression).FirstOrDefault();
    }

    public virtual Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
    {
        return Task.Run(() => _collection.Find(filterExpression).FirstOrDefaultAsync());
    }

    public virtual TDocument FindById(ObjectId id)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc._id, id);
        return _collection.Find(filter).SingleOrDefault();
    }

    public virtual Task<TDocument> FindByIdAsync(ObjectId id)
    {
        return Task.Run(() =>
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc._id, id);
            return _collection.Find(filter).SingleOrDefaultAsync();
        });
    }


    public virtual void Create(TDocument document)
    {
        _collection.InsertOne(document);
    }

    public virtual Task CreateAsync(TDocument document)
    {
        return Task.Run(() => _collection.InsertOneAsync(document));
    }

    public void Create(ICollection<TDocument> documents)
    {
        _collection.InsertMany(documents);
    }

    public virtual async Task CreateAsync(ICollection<TDocument> documents)
    {
        await _collection.InsertManyAsync(documents);
    }

    public void Update(TDocument document)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc._id, document._id);
        _collection.FindOneAndReplace(filter, document);
    }

    public virtual async Task UpdateAsync(TDocument document)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc._id, document._id);
        await _collection.FindOneAndReplaceAsync(filter, document);
    }

    public void Delete(Expression<Func<TDocument, bool>> filterExpression)
    {
        _collection.FindOneAndDelete(filterExpression);
    }

    public Task DeleteAsync(Expression<Func<TDocument, bool>> filterExpression)
    {
        return Task.Run(() => _collection.FindOneAndDeleteAsync(filterExpression));
    }

    public void DeleteById(ObjectId id)
    {
        var filter = Builders<TDocument>.Filter.Eq(doc => doc._id, id);
        _collection.FindOneAndDelete(filter);
    }

    public Task DeleteByIdAsync(ObjectId id)
    {
        return Task.Run(() =>
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc._id, id);
            _collection.FindOneAndDeleteAsync(filter);
        });
    }

    public void DeleteMany(Expression<Func<TDocument, bool>> filterExpression)
    {
        _collection.DeleteMany(filterExpression);
    }

    public Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression)
    {
        return Task.Run(() => _collection.DeleteManyAsync(filterExpression));
    }

    private protected string GetCollectionName(Type documentType)
    {
        return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                typeof(BsonCollectionAttribute),
                true)
            .FirstOrDefault())?.CollectionName;
    }
}
