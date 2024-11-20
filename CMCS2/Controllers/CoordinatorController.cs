using CMCS2.Data;
using CMCS2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMCS2.Controllers
{
    [Authorize(Roles = "Coordinator, SuperUser")]
    public class CoordinatorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CoordinatorController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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
                ViewBag.UserName = "Coordinator";
            }
            return View();
        }

        public IActionResult TrackClaims()
        {
            return View();
        }

        public ActionResult ViewUnapprovedClaims()
        {
            var unapprovedClaims = _context.Claims.Where(c => c.Status == "Pending").ToList();
            return View(unapprovedClaims);
        }

        public ActionResult ViewVerifiedClaims()
        {
            var verifiedClaims = _context.Claims.Where(c => c.Status == "Verified").ToList();
            return View(verifiedClaims);
        }

        public ActionResult ViewRejectedClaims()
        {
            var rejectedClaims = _context.Claims.Where(c => c.Status == "Rejected").ToList();
            return View(rejectedClaims);
        }

        // Coordinator approves a claim (moves status to 'Verified')
        public async Task<IActionResult> ApproveClaim(int claimId)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == claimId);

            if (claim != null && claim.Status == "Pending")
            {
                var coordinator = await _userManager.GetUserAsync(User);

                claim.Status = "Verified";
                claim.CoordinatorFullName = $"{coordinator.Name} {coordinator.Surname}";
                claim.DateVerified = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("ViewUnapprovedClaims", "Coordinator");
        }

        // Coordinator rejects a claim (moves status to 'Rejected')
        public async Task<IActionResult> RejectClaim(int claimId, string rejectionReason)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == claimId);

            if (claim != null && claim.Status == "Pending")
            {
                claim.Status = "Rejected";
                claim.RejectionReason = rejectionReason;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("ViewUnapprovedClaims", "Coordinator");
        }
    }
}