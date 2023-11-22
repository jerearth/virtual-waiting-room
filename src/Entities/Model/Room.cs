namespace Entities.Model
{
    public class Room : BaseEntity
    {
        // relations
        public List<RoomAdmin> RoomAdmins { get; set; } = new();
        public List<AllowedUser> AllowedUsers { get; set; } = new();
        public List<QueuedUser> QueuedUsers { get; set; } = new();
    }
}
