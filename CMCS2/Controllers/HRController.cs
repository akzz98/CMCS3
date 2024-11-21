using CMCS2.Data;
using CMCS2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CMCS2.Controllers
{
    [Authorize(Roles = "HR, SuperUser")]
    public class HRController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HRController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                ViewBag.UserName = user.Name;
            }
            else
            {
                ViewBag.UserName = "Manager";
            }
            return View();
        }


        public ActionResult ViewApprovedClaims()
        {
            var approvedClaims = _context.Claims.Where(c => c.Status == "Approved").ToList();
            return View(approvedClaims);
        }

        public IActionResult GenerateReport()
        {
            // Logic to generate report using ssrs
            // This could involve fetching data and passing it to a report generator
            return View();
        }
    }
}