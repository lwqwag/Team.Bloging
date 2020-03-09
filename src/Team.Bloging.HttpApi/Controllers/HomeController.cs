using Microsoft.AspNetCore.Mvc;

namespace Team.Blogging.Controllers
{
    public class HomeController : BlogingController
    {
        public ActionResult Index()
        {
            return Redirect("/blog/");
        }
    }
}