using Microsoft.AspNetCore.Mvc;

namespace Meoweb.Controllers {

    public class HomeController : Controller {
        
        public string Index() {
            return "This is Home Index";
        }

    }
}
