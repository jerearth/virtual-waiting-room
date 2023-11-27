using Entities.Enums;

namespace Entities.Model
{
    public class QueuedUser : BaseEntity
    {
        public int Order { get; set; } = 1;
        public QueueState QueueState { get; set; } = QueueState.Pending;

        // Relations
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public int ReasonId { get; set; }
        public Room Room { get; set; } = null!;
        public User User { get; set; } = null!;
        public Reason Reason { get; set; } = null!;
    }
}
