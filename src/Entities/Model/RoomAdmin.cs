namespace Entities.Model
{
    public class RoomAdmin : BaseEntity
    {
        // Relations
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
