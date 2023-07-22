using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EnigmaShopAPI.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _appDbContext;

    public Repository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<TEntity> SaveAsync(TEntity entity)
    {
        var entry = await _appDbContext.Set<TEntity>().AddAsync(entity);
        return entry.Entity;
    }

    public TEntity Attach(TEntity entity)
    {
        var entry =  _appDbContext.Set<TEntity>().Attach(entity);
        return entry.Entity;
    }

    public async Task<TEntity?> FindByIdAsync(Guid id)
    {
        return await _appDbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria)
    {
        return await _appDbContext.Set<TEntity>().FirstOrDefaultAsync(criteria);
    }

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria, string[] includes)
    {
        var query = _appDbContext.Set<TEntity>().AsQueryable();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(criteria);
    }

    public async Task<List<TEntity>> FindAllAsync()
    {
        return await _appDbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria)
    {
        return await _appDbContext.Set<TEntity>().Where(criteria).ToListAsync();
    }

    public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria, string[] includes)
    {
        var query = _appDbContext.Set<TEntity>().AsQueryable();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        
        return await query.Where(criteria).ToListAsync();
    }

    public TEntity Update(TEntity entity)
    {
        Attach(entity);
        _appDbContext.Set<TEntity>().Update(entity);
        return entity;
    }

    public void Delete(TEntity entity)
    {
        _appDbContext.Set<TEntity>().Remove(entity);
    }
}