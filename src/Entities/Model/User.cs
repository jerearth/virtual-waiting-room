using Entities.Enums;
using Entities.Model.Shared;

namespace Entities.Model
{
    public class User : BaseEntity
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public UserRole UserRole { get; set; } = UserRole.Basic;

        // relations
        public List<RoomAdmin> AdminForRooms { get; set; } = [];
        public List<AllowedUser> AllowedInRooms { get; set; } = [];
        public List<QueuedUser> QueuedInRooms { get; set; } = [];
    }
}
