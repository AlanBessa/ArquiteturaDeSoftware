using MWS.Infra.Persistence;
using MWS.SharedKernel;
using MWS.SharedKernel.Events;

namespace MWS.ApplicationService
{
    public class ApplicationService
    {
        private IUnitOfWork _unitOfWork;
        private IHandler<DomainNotification> _notifications;

        public ApplicationService(IUnitOfWork uof)
        {
            _unitOfWork = uof;
            _notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications())
                return false;

            _unitOfWork.Commit();
            return true;
        }
    }
}