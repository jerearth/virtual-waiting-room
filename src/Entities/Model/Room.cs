using Entities.Enums;
using Entities.Model.Shared;

namespace Entities.Model
{
    public class Room : BaseEntity
    {
        public required string Name { get; set; }
        public int? DailyLimit { get; set; }
        public string? Notes { get; set; }
        public string? OpeningHours { get; set; }
        public string Password { get; set; } = string.Empty;
        public string QRCode { get; set; } = Guid.NewGuid().ToString();
        public RoomType RoomType { get; set; } = RoomType.Private;

        // relations
        public List<RoomAdmin> RoomAdmins { get; set; } = [];
        public List<AllowedUser> AllowedUsers { get; set; } = [];
        public List<QueuedUser> QueuedUsers { get; set; } = [];
        public List<Reason> Reasons { get; set; } = [];
    }
}
