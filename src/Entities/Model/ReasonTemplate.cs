using Entities.Enums;
using Entities.Model.Shared;

namespace Entities.Model
{
    public class ReasonTemplate : BaseEntity
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public string Color { get; set; }
    }
}
