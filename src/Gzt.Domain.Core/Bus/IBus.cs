using Gzt.Domain.Core.Commands;
using Gzt.Domain.Core.Events;

namespace Gzt.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}