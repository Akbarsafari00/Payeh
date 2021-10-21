using System.Threading.Tasks;
using Payeh.DomainDrivenDesign.Events;

namespace Payeh.ApplicationService.Events
{
    public interface IEventDispatcher
    {
        Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent;

    }
}
