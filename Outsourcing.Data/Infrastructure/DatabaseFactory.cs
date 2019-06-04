using Outsourcing.Data.Models;

namespace Outsourcing.Data.Infrastructure
{
public class DatabaseFactory : Disposable, IDatabaseFactory
{
    private OutsourcingDBEntities dataContext;
    public OutsourcingDBEntities Get()
    {
        return dataContext ?? (dataContext = new OutsourcingDBEntities());
    }
    protected override void DisposeCore()
    {
        if (dataContext != null)
            dataContext.Dispose();
    }
}
}
