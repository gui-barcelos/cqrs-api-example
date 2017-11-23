using System;
using CQRSExample.ProductApi.Domain.Interfaces.UnitOfWork;
using CQRSExample.ProductApi.Infra.Data.Context;

namespace CQRSExample.ProductApi.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductsContext _context;

        public UnitOfWork(ProductsContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
