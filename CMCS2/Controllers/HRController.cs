using CMCS2.Data;
using CMCS2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
                ViewBag.UserName = "HR";
            }
            return View();
        }

        public ActionResult ViewApprovedClaims()
        {
            var approvedClaims = _context.Claims.Where(c => c.Status == "Approved").ToList();
            return View(approvedClaims);
        }

        public IActionResult GenerateReport(int? claimId)
        {
            if (claimId.HasValue)
            {
                var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == claimId);
                if (claim == null) return NotFound("Claim not found.");

                ViewBag.ReportServerUrl = "http://localhost/ReportServer";
                ViewBag.ReportPath = "/Reports/HRReports/IndividualClaimReport";
                ViewBag.ClaimId = claimId;

                return View("IndividualReport");
            }

            ViewBag.ReportServerUrl = "http://localhost/ReportServer";
            ViewBag.ReportPath = "/Reports/HRReports/ApprovedClaimsSummary";
            return View("SummaryReport");
        }

        public IActionResult GenerateAllReports()
        {
            ViewBag.ReportServerUrl = "http://localhost/ReportServer";
            ViewBag.ReportPath = "/Reports/HRReports/ApprovedClaimsSummary";

            return View("SummaryReport");
        }
    }
}
