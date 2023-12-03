using Entities.Enums;
using Entities.Model.Shared;

namespace Entities.Model
{
    public class QueuedUser : BaseEntity
    {
        public required int Order { get; set; }
        public required QueueState QueueState { get; set; }
        public required string PhoneNumber { get; set; }
        public required int NotificationMinutesInAdvance { get; set; }

        // Relations
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public int ReasonId { get; set; }
        public Room Room { get; set; } = null!;
        public User User { get; set; } = null!;
        public Reason Reason { get; set; } = null!;
    }
}
