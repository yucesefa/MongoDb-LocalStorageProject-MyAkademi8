using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.ViewComponents
{
    public class _AdminLayoutNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
