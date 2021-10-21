using System.Threading.Tasks;
using Payeh.DomainDrivenDesign.Events;

namespace Payeh.ApplicationService.Events
{
    public interface IDomainEventHandler<TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
        Task Handle(TDomainEvent Event);
    }
}
