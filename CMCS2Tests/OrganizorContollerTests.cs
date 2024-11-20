using CMCS2.Controllers;
using CMCS2.Data;
using CMCS2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;


namespace CMCS2Tests
{
    [TestClass]
    public class OrganizationControllerTests
    {
        private ApplicationDbContext _context;
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private OrganizationController _controller;

        [TestInitialize]
        public void Setup()
        {
            // Use in-memory database for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);

            _mockUserManager = new Mock<UserManager<ApplicationUser>>(
                new Mock<IUserStore<ApplicationUser>>().Object,
                null, null, null, null, null, null, null, null);

            _controller = new OrganizationController(_context, _mockUserManager.Object);
        }

        [TestMethod]
        public async Task Index_UserExists_SetsUserNameInViewBag()
        {
            // Arrange
            var user = new ApplicationUser { Name = "Test User" };
            _mockUserManager.Setup(um => um.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>())).ReturnsAsync(user);

            // Act
            var result = await _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test User", _controller.ViewBag.UserName);
        }

        [TestMethod]
        public async Task Index_UserDoesNotExist_SetsDefaultUserNameInViewBag()
        {
            // Arrange
            _mockUserManager.Setup(um => um.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>())).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Manager", _controller.ViewBag.UserName);
        }

        [TestMethod]
        public void ViewRejectedClaims_ReturnsRejectedClaims()
        {
            // Arrange
            _context.Claims.AddRange(new List<Claim>
    {
        new Claim
        {
            ClaimId = 1,
            Status = "Rejected",
            DocumentPath = "/uploads/test.pdf",
            LecturerFullName = "John Doe",
            LecturerId = "lecturer123",
            Notes = "Test notes",
            HoursWorked = 10,
            HourlyRate = 20,
            DateSubmitted = DateTime.Now
        },
        new Claim
        {
            ClaimId = 2,
            Status = "Approved",
            DocumentPath = "/uploads/test2.pdf",
            LecturerFullName = "Jane Smith",
            LecturerId = "lecturer456",
            Notes = "More test notes",
            HoursWorked = 15,
            HourlyRate = 25,
            DateSubmitted = DateTime.Now
        }
    });
            _context.SaveChanges();

            // Act
            var result = _controller.ViewRejectedClaims() as ViewResult;
            var model = result.Model as List<Claim>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, model.Count);
            Assert.AreEqual("Rejected", model[0].Status);
        }

        // Test: Final Aproval test
        [TestMethod]
        public async Task FinalizeApproval_ChangesStatusToApproved()
        {
            // Arrange
            var claim = new Claim
            {
                ClaimId = 1,
                Status = "Verified",
                DocumentPath = "/uploads/test.pdf",
                LecturerFullName = "John Doe",
                LecturerId = "lecturer123",
                Notes = "Test notes",
                HoursWorked = 10,
                HourlyRate = 20,
                DateSubmitted = DateTime.Now
            };
            _context.Claims.Add(claim);
            _context.SaveChanges();

            // Act
            var result = await _controller.FinalizeApproval(claim.ClaimId) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ViewVerifiedClaims", result.ActionName);
            var updatedClaim = _context.Claims.FirstOrDefault(c => c.ClaimId == claim.ClaimId);
            Assert.IsNotNull(updatedClaim);
            Assert.AreEqual("Approved", updatedClaim.Status);
        }

        // Test: Reject Verified Claim test
        [TestMethod]
        public async Task RejectVerifiedClaim_ChangesStatusToRejected()
        {
            // Arrange
            var claim = new Claim
            {
                ClaimId = 2,
                Status = "Verified",
                DocumentPath = "/uploads/test2.pdf",
                LecturerFullName = "Jane Smith",
                LecturerId = "lecturer456",
                Notes = "More test notes",
                HoursWorked = 15,
                HourlyRate = 25,
                DateSubmitted = DateTime.Now
            };
            _context.Claims.Add(claim);
            _context.SaveChanges();

            string rejectionReason = "Insufficient documentation";

            // Act
            var result = await _controller.RejectVerifiedClaim(claim.ClaimId, rejectionReason) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ViewVerifiedClaims", result.ActionName);
            var updatedClaim = _context.Claims.FirstOrDefault(c => c.ClaimId == claim.ClaimId);
            Assert.IsNotNull(updatedClaim);
            Assert.AreEqual("Rejected", updatedClaim.Status);
            Assert.AreEqual(rejectionReason, updatedClaim.RejectionReason);
        }
    }
}
