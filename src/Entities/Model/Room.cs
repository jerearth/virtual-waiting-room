using Entities.Enums;
using Entities.Model.Shared;

namespace Entities.Model
{
    public class Room : BaseEntity
    {
        public required string Name { get; set; }
        public required string SearchName { get; set; }
        public int? DailyLimit { get; set; }
        public string? Notes { get; set; }
        public string? OpeningHours { get; set; }
        public string QRCode { get; set; } = Guid.NewGuid().ToString();
        public bool AppearInSearch { get; set; }
        public string? Password { get; set; }
        public bool RequireConfirmation { get; set; }

        // relations
        public List<RoomAdmin> RoomAdmins { get; set; } = [];
        public List<AllowedUser> AllowedUsers { get; set; } = [];
        public List<QueuedUser> QueuedUsers { get; set; } = [];
        public List<Reason> Reasons { get; set; } = [];
    }
}
