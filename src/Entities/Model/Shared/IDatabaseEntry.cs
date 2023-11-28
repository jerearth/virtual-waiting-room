namespace Entities.Model.Shared
{
    public interface IDatabaseEntry
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }
    }
}
