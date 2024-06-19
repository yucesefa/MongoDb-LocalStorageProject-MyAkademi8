using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.ViewComponents
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
