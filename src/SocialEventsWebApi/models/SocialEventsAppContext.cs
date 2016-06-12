using Microsoft.Data.Entity;

namespace SocialEventsWebApi.models
{
    public class SocialEventsAppContext : DbContext
    {
        public DbSet<SocialEvent> SocialEvents { get; set; }
    }
}
