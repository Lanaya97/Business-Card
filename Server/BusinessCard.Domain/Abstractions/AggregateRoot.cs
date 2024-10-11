using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessCard.Domain.Abstractions
{
    public interface IAggregateRoot<TId> where TId : IEquatable<TId>
    {
        TId Id { get; }

        bool IsDeleted { get; }
    }
    public abstract class AggregateRoot<TId> : AuditableEntity, IAggregateRoot<TId> where TId : IEquatable<TId>
    {

        /// <summary>
        /// The aggregate root Id
        /// </summary>
        ///
        [Key]
        public TId Id { get; protected set; }

        /// <summary>
        /// Indicates whether this aggregate is logically deleted
        /// </summary>
        /// 
        public bool IsDeleted { get; private set; }

        protected void MarkAsDeleted()
        {
            IsDeleted = true;
        }


    }
}