namespace Entities.Model
{
    public class User : IdentityUser<int>, IDatabaseEntry
    {
        public DateTime Created { get; set; }

        // relations
        public List<RoomAdmin> AdminForRooms { get; set; } = new();
        public List<AllowedUser> AllowedInRooms { get; set; } = new();
        public List<QueuedUser> QueuedInRooms { get; set; } = new();
    }
}
