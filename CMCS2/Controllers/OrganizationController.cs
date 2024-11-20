using CMCS2.Data;
using CMCS2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMCS2.Controllers
{
    [Authorize(Roles = "Manager, SuperUser")]
    public class OrganizationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrganizationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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

        public IActionResult TrackClaims()
        {
            return View();
        }
        public ActionResult ViewRejectedClaims()
        {
            var rejectedClaims = _context.Claims.Where(c => c.Status == "Rejected").ToList();
            return View(rejectedClaims);
        }
        public ActionResult ViewVerifiedClaims()
        {
            var verifiedClaims = _context.Claims.Where(c => c.Status == "Verified").ToList();
            return View(verifiedClaims);
        }

        public ActionResult ViewApprovedClaims()
        {
            var approvedClaims = _context.Claims.Where(c => c.Status == "Approved").ToList();
            return View(approvedClaims);
        }

        // Manager finalizes approval (moves status to 'Approved')
        public async Task<IActionResult> FinalizeApproval(int claimId)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == claimId);

            if (claim != null && claim.Status == "Verified")
            {
                claim.Status = "Approved";
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("ViewVerifiedClaims", "Organization");
        }

        // Manager rejects a verified claim (moves status to 'Rejected')
        public async Task<IActionResult> RejectVerifiedClaim(int claimId, string rejectionReason)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == claimId);

            if (claim != null && claim.Status == "Verified")
            {
                claim.Status = "Rejected";
                claim.RejectionReason = rejectionReason;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("ViewVerifiedClaims", "Organization");
        }
    }
}
