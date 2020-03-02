using MediatR;
using System;
using System.Collections.Generic;

namespace Pedidos.Domain.SeedWork
{
    public abstract class AEntity
    {
        private int _id;
        public virtual int Id
        {
            get { return _id; }
            protected set { _id = value; }
        }

        int? _requestedHashCode;

        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(INotification domainEvent)
        {
            _domainEvents?.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public bool IsTransient()
        {
            return Id == default(long);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is AEntity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            AEntity entity = (AEntity)obj;

            if (entity.IsTransient() || this.IsTransient())
                return false;
            else
                return entity.Id == this.Id;
        }

        // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31;

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }

        public static bool operator ==(AEntity left, AEntity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(AEntity left, AEntity right)
        {
            return !(left == right);
        }
    }
}