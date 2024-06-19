using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.ViewComponents
{
    public class _AdminLayoutSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        { return View(); }
    }
}
