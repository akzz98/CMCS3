using CMCS2.Controllers;
using CMCS2.Data;
using CMCS2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS2Tests
{
    [TestClass]
    public class CoordinatorControllerTests
    {
        private Mock<UserManager<ApplicationUser>> _userManagerMock;
        private ApplicationDbContext _context;
        private CoordinatorController _controller;

        [TestInitialize]
        public void Setup()
        {
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(
                new Mock<IUserStore<ApplicationUser>>().Object, null, null, null, null, null, null, null, null);

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);

            // Seed the database with test data
            _context.Claims.AddRange(new List<Claim>
            {
                new Claim { ClaimId = 1, Status = "Pending", DocumentPath = "path1", LecturerFullName = "John Doe", LecturerId = "lecturer1", Notes = "Test notes 1" },
                new Claim { ClaimId = 2, Status = "Verified", DocumentPath = "path2", LecturerFullName = "Jane Doe", LecturerId = "lecturer2", Notes = "Test notes 2" },
                new Claim { ClaimId = 3, Status = "Rejected", DocumentPath = "path2", LecturerFullName = "Jane Doe", LecturerId = "lecturer3", Notes = "Test notes 2" },
                new Claim { ClaimId = 4, Status = "Pending", DocumentPath = "path3", LecturerFullName = "John Smith", LecturerId = "lecturer4", Notes = "Test notes 3" },
                new Claim { ClaimId = 5, Status = "Rejected", DocumentPath = "path4", LecturerFullName = "Jane Smith", LecturerId = "lecturer5", Notes = "Test notes 4" }
            });
            _context.SaveChanges();

            _controller = new CoordinatorController(_context, _userManagerMock.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        //Test: Name is displayed in the view
        [TestMethod]
        public async Task Index_ReturnsViewWithUserName()
        {
            // Arrange
            var user = new ApplicationUser { Name = "TestUser" };
            _userManagerMock.Setup(um => um.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                .ReturnsAsync(user);

            // Act
            var result = await _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("TestUser", result.ViewData["UserName"]);
        }

        //Test: View Unnaproved claims 
        [TestMethod]
        public void ViewUnapprovedClaims_ReturnsViewWithUnapprovedClaims()
        {
            // Act
            var result = _controller.ViewUnapprovedClaims() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var model = result.Model as List<Claim>;
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Count);
            Assert.IsTrue(model.All(c => c.Status == "Pending"));
        }

        //Test: View rejected claims
        [TestMethod]
        public void ViewRejectedClaims_ReturnsViewWithRejectedClaims()
        {
            // Act
            var result = _controller.ViewRejectedClaims() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var model = result.Model as List<Claim>;
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Count);
            Assert.IsTrue(model.All(c => c.Status == "Rejected"));
        }

        //Test: Check verification process and change status to verified
        [TestMethod]
        public async Task ApproveClaim_ValidClaimId_UpdatesClaimStatusToVerified()
        {
            // Arrange
            var user = new ApplicationUser { Name = "Coordinator", Surname = "User" };
            _userManagerMock.Setup(um => um.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                .ReturnsAsync(user);

            // Act
            var result = await _controller.ApproveClaim(1) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ViewUnapprovedClaims", result.ActionName);

            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == 1);
            Assert.IsNotNull(claim);
            Assert.AreEqual("Verified", claim.Status);
            Assert.AreEqual("Coordinator User", claim.CoordinatorFullName);
            Assert.IsNotNull(claim.DateVerified);
        }

        //Test: Test rejection
        [TestMethod]
        public async Task RejectClaim_ValidClaimId_UpdatesClaimStatusToRejected()
        {
            // Arrange
            string rejectionReason = "Insufficient documentation";

            // Act
            var result = await _controller.RejectClaim(1, rejectionReason) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ViewUnapprovedClaims", result.ActionName);

            var claim = _context.Claims.FirstOrDefault(c => c.ClaimId == 1);
            Assert.IsNotNull(claim);
            Assert.AreEqual("Rejected", claim.Status);
            Assert.AreEqual(rejectionReason, claim.RejectionReason);
        }
    }
}
