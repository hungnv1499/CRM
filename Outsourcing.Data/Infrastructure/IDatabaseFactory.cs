using Outsourcing.Data.Models;
using System;

namespace Outsourcing.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        OutsourcingDBEntities Get();
    }
}
