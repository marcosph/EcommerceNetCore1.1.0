using Gzt.Domain.Core.Commands;
using Gzt.Domain.Interfaces;
using Gzt.Infra.Data.Context;

namespace Gzt.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GztContext _context;

        public UnitOfWork(GztContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
