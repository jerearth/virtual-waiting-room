namespace Entities.Model
{
    public class QueuedUser : BaseEntity
    {
        public int Order { get; set; }


        // Relations
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
