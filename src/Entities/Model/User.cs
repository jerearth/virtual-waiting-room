namespace Entities.Model
{
    public class User : BaseEntity
    {
        public string PhoneNumber { get; set; }

        // relations
        public List<RoomAdmin> AdminForRooms { get; set; } = new();
        public List<AllowedUser> AllowedInRooms { get; set; } = new();
        public List<QueuedUser> QueuedInRooms { get; set; } = new();
    }
}
