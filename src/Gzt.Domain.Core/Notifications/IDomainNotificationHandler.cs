using System.Collections.Generic;
using Gzt.Domain.Core.Events;

namespace Gzt.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}