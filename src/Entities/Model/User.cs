using Entities.Enums;
using Entities.Model.Shared;

namespace Entities.Model
{
    public class User : IdentityUser<int>, IDatabaseEntry
    {
        public DateTime Created { get; set; }

        // relations
        public List<RoomAdmin> AdminForRooms { get; set; } = [];
        public List<AllowedUser> AllowedInRooms { get; set; } = [];
        public List<QueuedUser> QueuedInRooms { get; set; } = [];
    }
}
