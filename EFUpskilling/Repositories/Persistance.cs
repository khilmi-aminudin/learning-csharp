namespace EFUpskilling.Repositories;

public class Persistance : IPersistance
{
    private readonly AppDbContext _appDbContext;

    public Persistance(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void SaveChanges()
    {
        _appDbContext.SaveChanges();
    }

    public void BeginTransaction()
    {
        _appDbContext.Database.BeginTransaction();
    }

    public void Commit()
    {
        _appDbContext.Database.CommitTransaction();
    }

    public void Rollback()
    {
        _appDbContext.Database.RollbackTransaction();
    }
}