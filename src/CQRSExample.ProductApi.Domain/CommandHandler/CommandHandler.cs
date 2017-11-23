using CQRSExample.ProductApi.Domain.Interfaces.UnitOfWork;

namespace CQRSExample.ProductApi.Domain.CommandHandler
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;

        public CommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected void Commit()
        {
            _uow.Commit();
        }
    }
}
