using Entities.Enums;

namespace Entities.Model
{
    public class RoomTemplate : BaseEntity
    {
        public int DailyLimit { get; set; }
        public RoomType RoomType { get; set; } = RoomType.Private;

        // Relations
        public List<ReasonTemplate> Reasons { get; set; } = [];
    }
}
