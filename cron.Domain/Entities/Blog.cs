using cron.Domain.Entities.Common;

namespace cron.Domain.Entities
{
    public class Blog:BaseEntity
    {
        public string Content { get; set; }
        public string ImageUrl { get; set; }
    }
}
