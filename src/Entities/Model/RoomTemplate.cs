using Entities.Enums;
using Entities.Model.Shared;

namespace Entities.Model
{
    public class RoomTemplate : BaseEntity
    {
        public int DailyLimit { get; set; }

        // Relations
        public List<ReasonTemplate> Reasons { get; set; } = [];
    }
}
