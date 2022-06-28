using Infrastructure.Entities.Security;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public abstract class EntityWithAudit<T> : Audit , IEntity<T>
    { 
        /// <summary>
        /// Default Constructor. If T is <see cref="System.Guid"/>, the value of the Id property is automatically set.
        /// </summary>
        protected EntityWithAudit()
        {
            if (typeof(T) == typeof(Guid))
            {
                Id = (T)(object)Guid.NewGuid();
            }
        }

        /// <summary>
        /// Overloaded constructor.
        /// </summary>
        /// <param name="id">An <see cref="T"/> that 
        /// represents the primary identifier value for the 
        /// class.</param>
        protected EntityWithAudit(T id)
        {
            Id = id;
        }


        /// <summary>
        /// An <see cref="Entity{T}"/> that represents the 
        /// primary identifier value for the class.
        /// </summary>
        [Key]
        public T Id { get; set; }

        object IEntity.Id
        {
            get => this.Id;
            set => this.Id = (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
