using CMCS2.Data;
using CMCS2.Models;
using CMCS3.Automation;
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
        private readonly ApprovalValidator _approvalValidator;

        public OrganizationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _approvalValidator = new ApprovalValidator();
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

        // Auto Approve the claim
        public async Task<IActionResult> ApproveClaim(int claimId)
        {
            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == claimId);

            if (claim != null && claim.Status == "Verified")
            {
                var validationResult = _approvalValidator.Validate(claim);
                if (!validationResult.IsValid)
                {
                    
                    // Collect all validation error messages
                    var rejectionReason = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));

                    // Set the rejection reason in the claim
                    claim.RejectionReason = rejectionReason;
                    claim.Status = "Rejected";
                   
                    // Save the claim with the rejection reason
                    await _context.SaveChangesAsync();

                    return RedirectToAction("ViewVerifiedClaims");
                }

                // Process the claim if valid
                var manager = await _userManager.GetUserAsync(User);
                claim.Status = "Approved";
                claim.ManagerFullName = $"{manager.Name} {manager.Surname}";
                claim.DateApproved = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("ViewVerifiedClaims");
        }
    }
}
