using System.Web.Mvc;
using Known.WebMvc.Models;

namespace Known.WebMvc.Controllers
{
    public class FrameController : AuthorizeController
    {
        public ActionResult Index(string id)
        {
            var module = PlatformService.GetModule(id);
            if (module == null)
                return Content("模块不存在！");

            switch (module.ViewType)
            {
                case Known.Core.ViewType.DataGridView:
                    return View("DataGridView", new DataGridViewModel(module));
                case Known.Core.ViewType.TreeGridView:
                    return View("TreeGridView", new TreeGridViewModel(module));
                case Known.Core.ViewType.TabPageView:
                    return View("TabPageView", new TabPageViewModel(module));
                case Known.Core.ViewType.SplitPageView:
                    return View("SplitPageView", new SplitPageViewModel(module));
                default:
                    return View(module);
            }
        }
    }
}