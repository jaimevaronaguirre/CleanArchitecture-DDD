using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Abstractions
{
    public abstract class Entity
    {
        //Clase base o plantilla para crear Guid
        private readonly List<IDomainEvent> _domainEvent = new();
        protected Entity(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; init; }

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _domainEvent.ToList();
        }

        public void ClearDomainEvent()
        {
            _domainEvent.Clear();
        }
        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvent.Add(domainEvent);
        }
    }
}
