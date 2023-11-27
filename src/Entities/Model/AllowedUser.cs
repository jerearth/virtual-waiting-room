using Entities.Model.Shared;

namespace Entities.Model
{
    public class AllowedUser : BaseEntity
    {
        // Relations
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
