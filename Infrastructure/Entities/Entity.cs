using Infrastructure.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public abstract class Entity<T> : IEntity<T>    
    {
        /// <summary>
        /// Default Constructor. If T is <see cref="System.Guid"/>, the value of the Id property is automatically set.
        /// </summary>
        protected Entity()
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
        protected Entity(T id)
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
