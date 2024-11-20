using CMCS2.Data;
using CMCS2.Models;
using Elfie.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMCS2.Controllers
{
    [Authorize(Roles = "Lecturer, SuperUser")]
    public class LecturerController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public LecturerController(IWebHostEnvironment environment, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _environment = environment;
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
                ViewBag.UserName = "Lecturer"; 
            }

            return View();
        }



        public ActionResult SubmitClaim()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitClaim(double hoursWorked, double hourlyRate, string notes, IFormFile file)
        {
            // Check for hours worked and hourly rate
            if (hoursWorked <= 0)
            {
                ModelState.AddModelError(nameof(hoursWorked), "Hours worked must be greater than 0.");
            }

            if (hourlyRate <= 0)
            {
                ModelState.AddModelError(nameof(hourlyRate), "Hourly rate must be greater than 0.");
            }

            // Check if the model state is valid after the validation checks
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                var claim = new Claim
                {
                    HoursWorked = hoursWorked,
                    HourlyRate = hourlyRate,
                    Notes = notes,
                    Status = "Pending",
                    DateSubmitted = DateTime.Now,
                    LecturerId = _userManager.GetUserId(User),
                    LecturerFullName = $"{user.Name} {user.Surname}"
                };

                // Handle file upload
                if (file != null && file.Length > 0)
                {
                    // Restrict file size to 10MB
                    if (file.Length > 10 * 1024 * 1024)
                    {
                        ModelState.AddModelError("", "File size cannot exceed 10MB.");
                        return View();
                    }

                    // Restrict file type
                    var allowedExtensions = new[] { ".pdf", ".jpg", ".png" };
                    var fileExtension = Path.GetExtension(file.FileName).ToLower();
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError("", "Only .pdf, .jpg, and .png files are allowed.");
                        return View();
                    }

                    // Save the file in wwwroot/uploads
                    var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Store only the relative path to the file
                    claim.DocumentPath = "/uploads/" + uniqueFileName;
                }

                // Save the claim to the database
                _context.Claims.Add(claim);
                await _context.SaveChangesAsync();

                return RedirectToAction("ClaimSubmitted");
            }

            return View();
        }


        public IActionResult ClaimSubmitted()
        {
            return View();
        }

        public ActionResult TrackStatus()
        {
            // Get the currently logged-in user's ID
            var userId = _userManager.GetUserId(User);

            // Fetch claims where the LecturerId matches the current user's ID
            var claims = _context.Claims.Where(c => c.LecturerId == userId).ToList();

            return View(claims);
        }
    }
}
