namespace EFUpskilling.Repositories;

public  interface IRepository<TEntity>
{
    TEntity Save(TEntity entity);
    TEntity? FindById(Guid id);
    TEntity? Find(Func<TEntity, bool> predicate);
    IEnumerable<TEntity> FindAll();
    IEnumerable<TEntity> FindAll(Func<TEntity, bool> predicate);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}