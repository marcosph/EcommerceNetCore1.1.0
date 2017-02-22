﻿using Gzt.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace GazetaDoTocantins.UI.Site.Controllers
{
    public class BaseController : Controller
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public BaseController(IDomainNotificationHandler<DomainNotification> notifications)
        {
            _notifications = notifications;
        }

        public bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }
    }
}
