using System;

namespace BusinessCard.Domain.Abstractions
{
    public abstract class AuditableEntity
    {
        /// <summary>
        /// The date the entity was created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date the entity was last modified
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// The date the entity was last deleted
        /// </summary>
        public DateTime? DateDeleted { get; set; }

        /// <summary>
        /// The user who created the entity
        /// </summary>
        public int? CreatedById { get; set; }

        /// <summary>
        /// The user who last modified the entity
        /// </summary>
        public int? ModifiedById { get; set; }

        /// <summary>
        /// The user who last deleted the entity
        /// </summary>
        public int? DeletedById { get; set; }

    }
}