namespace Entities.Model.Shared
{
    public abstract class BaseEntity : IDatabaseEntry
    {
        /// <summary>
        /// Primary key of the entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date when was the entity created
        /// </summary>
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
