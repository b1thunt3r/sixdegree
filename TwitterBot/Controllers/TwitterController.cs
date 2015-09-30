using LinqToTwitter;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

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

            //var searchResponse =
            //    (from search in twitterCtx.Search
            //     where search.Type == SearchType.Search &&
            //           search.Query == "#mono"
            //     select search)
            //    .SingleOrDefault();
            var searchResponse = twitterCtx.Search
                .SingleOrDefault(s => s.Type == SearchType.Search && s.Query == "#windows10");

            //if (searchResponse != null && searchResponse.Statuses != null)
            //    searchResponse.Statuses.ForEach(tweet =>
            //        Console.WriteLine(
            //            "User: {0}, Tweet: {1}",
            //            tweet.User.ScreenNameResponse,
            //            tweet.Text));

            return View(searchResponse);
        }
    }
}