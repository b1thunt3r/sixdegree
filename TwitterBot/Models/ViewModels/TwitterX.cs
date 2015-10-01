
using LinqToTwitter;

namespace TwitterBot.Models.ViewModels
{
    public class TwitterX
    {
        public Search Search { get; set; }
        public Friendship Friendship { get; set; }
        public Friendship Followers { get; set; }
    }
}