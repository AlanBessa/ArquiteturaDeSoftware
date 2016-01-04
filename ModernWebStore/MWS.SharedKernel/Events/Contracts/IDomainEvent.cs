using System;

namespace MWS.SharedKernel.Events.Contracts
{
    public interface IDomainEvent
    {
        DateTime DateOccurred { get; }
    }
}