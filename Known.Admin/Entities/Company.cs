using Known.Mapping;

namespace Known.Admin.Entities
{
    public class Company : BaseEntity
    {
        public string ParentId { get; set; }
        public string Name { get; set; }
    }
}
