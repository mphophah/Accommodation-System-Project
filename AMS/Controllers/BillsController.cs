using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class BillsController : Controller
    {


        // GET: Accomondation/Rooms
        public IActionResult Payments() 
        {
            return View();
        }

        // GET: Accomondation/Rooms
        public IActionResult Invoice() 
        {
            return View();
        }
        
    }
    
}
