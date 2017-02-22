using System;
using Gzt.Domain.Core.Commands;

namespace Gzt.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
