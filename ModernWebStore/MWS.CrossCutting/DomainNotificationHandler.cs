using MWS.SharedKernel;
using MWS.SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MWS.CrossCutting
{
    public class DomainNotificationHandler : IHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public void Handle(DomainNotification args)
        {
            _notifications.Add(args);
        }

        public IEnumerable<DomainNotification> Notify()
        {
            return GetValue();
        }

        public bool HasNotifications()
        {
            return GetValue().Count > 0;
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }

        private List<DomainNotification> GetValue()
        {
            return _notifications;
        }
    }
}
