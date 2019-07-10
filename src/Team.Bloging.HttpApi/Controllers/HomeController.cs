using Microsoft.AspNetCore.Mvc;

namespace Team.Bloging.Controllers
{
    public class HomeController : BlogingController
    {
        public ActionResult Index()
        {
            return Redirect("/blog/");
        }
    }
}