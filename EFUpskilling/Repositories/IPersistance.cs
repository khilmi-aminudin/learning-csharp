namespace EFUpskilling.Repositories;

public interface IPersistance
{
    void SaveChanges();
    void BeginTransaction();
    void Commit();
    void Rollback();
}