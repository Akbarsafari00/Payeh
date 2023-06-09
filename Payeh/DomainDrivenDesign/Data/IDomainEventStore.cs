﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Payeh.DomainDrivenDesign.Events;

namespace Payeh.DomainDrivenDesign.Data
{
    public interface IDomainEventStore
    {
        void Save<TEvent>(string aggregateName, string aggregateId, IEnumerable<TEvent> events) where TEvent : IDomainEvent;
        Task SaveAsync<TEvent>(string aggregateName, string aggregateId, IEnumerable<TEvent> events) where TEvent : IDomainEvent;
    }
}
