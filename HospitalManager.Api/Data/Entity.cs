using System;

namespace HospitalManager.Api.Data
{
    public abstract class Entity
    {
        public Guid Id { get; }
        public DateTime CreatedAt { get; }
        public DateTime LastModified { get; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = LastModified = DateTime.UtcNow;
        }
    }
}