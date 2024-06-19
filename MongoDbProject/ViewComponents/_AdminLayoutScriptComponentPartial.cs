using Microsoft.AspNetCore.Mvc;

namespace MongoDbProject.ViewComponents
{
    public class _AdminLayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
