using Entities.Enums;

namespace Entities.Model
{
    public class ReasonTemplate : BaseEntity
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public string Color { get; set; }
    }
}
