using LinqToTwitter;
using System.Configuration;
using System.Web.Mvc;
using TwitterBot.Models.ViewModels;

namespace TwitterBot.Controllers
{
    public class TwitterController : Controller
    {
        // GET: Twitter
        public ActionResult Index()
        {
            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = ConfigurationManager.AppSettings["consumerKey"],
                    ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"],
                    AccessToken = ConfigurationManager.AppSettings["accessToken"],
                    AccessTokenSecret = ConfigurationManager.AppSettings["accessTokenSecret"]
                }
            };

            var twitterCtx = new TwitterContext(auth);
            var vm = new TwitterX(); ;

            //vm.Search = twitterCtx.Search
            //    .SingleOrDefault(s => s.Type == SearchType.Search && s.Query == "#windows10");

            //vm.Friendship = twitterCtx.Friendship
            //    .SingleOrDefault(f => f.Type == FriendshipType.FriendsList & f.ScreenName == "aschmach" && f.Count == 10000);

            //vm.Followers = twitterCtx.Friendship
            //    .SingleOrDefault(f => f.Type == FriendshipType.FollowersList & f.ScreenName == "aschmach" && f.Count == 10000);

            return View(twitterCtx);
        }
    }
}