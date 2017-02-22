﻿using System;
using System.Collections.Generic;
using Gzt.Domain.Core.Events;

namespace Gzt.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}