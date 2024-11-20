using CMCS2.Controllers;
using CMCS2.Data;
using CMCS2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CMCS2Tests
{
    [TestClass]
    public class LecturerControllerTests
    {
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private Mock<IWebHostEnvironment> _mockEnvironment;
        private ApplicationDbContext _mockContext;

        [TestInitialize]
        public void Setup()
        {
            _mockUserManager = MockUserManager<ApplicationUser>();
            _mockEnvironment = new Mock<IWebHostEnvironment>();

            // Set up the WebRootPath to a valid directory
            string webRootPath = "C:\\Temp";
            _mockEnvironment.Setup(e => e.WebRootPath).Returns(webRootPath);

            // Ensure the uploads directory exists
            string uploadsPath = Path.Combine(webRootPath, "uploads");
            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase("TestDatabase")
                          .Options;

            _mockContext = new ApplicationDbContext(options);
        }

        //Test if user's name is properly displayed in the viewbag(Index).
        [TestMethod]
        public async Task Index_ReturnsCorrectUserNameInViewBag_WhenUserIsLoggedIn()
        {
            // Arrange
            var user = new ApplicationUser { Name = "Alton", Surname = "Zulu" };

            // Mock UserManager behavior to return the mock user
            _mockUserManager.Setup(um => um.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                            .ReturnsAsync(user);

            var controller = new LecturerController(_mockEnvironment.Object, _mockContext, _mockUserManager.Object);

            // Act
            var result = await controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Alton", result.ViewData["UserName"]);
        }

        //Test if default is properly displayed if theres no user name.
        [TestMethod]
        public async Task Index_ReturnsDefaultUserName_WhenNoUserIsLoggedIn()
        {
            // Arrange
            // Mock UserManager behavior to return null (no logged-in user)
            _mockUserManager.Setup(um => um.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                            .ReturnsAsync((ApplicationUser)null);

            var controller = new LecturerController(_mockEnvironment.Object, _mockContext, _mockUserManager.Object);

            // Act
            var result = await controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Lecturer", result.ViewData["UserName"]);
        }

        // Test: Valid claim submission
        [TestMethod]
        public async Task SubmitClaim_ValidData_ReturnsRedirectToClaimSubmitted()
        {
            // Arrange
            var user = new ApplicationUser { Name = "John", Surname = "Doe" };

            _mockUserManager.Setup(um => um.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                            .ReturnsAsync(user);
            _mockUserManager.Setup(um => um.GetUserId(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                            .Returns("user-id");

            var controller = new LecturerController(_mockEnvironment.Object, _mockContext, _mockUserManager.Object);

            var mockFile = new Mock<IFormFile>();
            var content = "Fake file content";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            mockFile.Setup(_ => _.OpenReadStream()).Returns(ms);
            mockFile.Setup(_ => _.FileName).Returns(fileName);
            mockFile.Setup(_ => _.Length).Returns(ms.Length);

            double hoursWorked = 5;
            double hourlyRate = 50;

            // Act
            var result = await controller.SubmitClaim(hoursWorked, hourlyRate, "Valid claim", mockFile.Object) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ClaimSubmitted", result.ActionName);
        }

        // Test: Invalid claim submission (Zero or negative values)
        [TestMethod]
        public async Task SubmitClaim_InvalidData_ReturnsModelError()
        {
            // Arrange
            var user = new ApplicationUser { Name = "John", Surname = "Doe" };

            _mockUserManager.Setup(um => um.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                            .ReturnsAsync(user);

            var controller = new LecturerController(_mockEnvironment.Object, _mockContext, _mockUserManager.Object);

            var mockFile = new Mock<IFormFile>();
            mockFile.Setup(f => f.Length).Returns(1024);
            mockFile.Setup(f => f.FileName).Returns("test.pdf");


            double hoursWorked = -5;
            double hourlyRate = -50;

            // Act
            var result = await controller.SubmitClaim(hoursWorked, hourlyRate, "Invalid claim", mockFile.Object) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, controller.ModelState.ErrorCount);
            Assert.IsTrue(controller.ModelState.ContainsKey(nameof(hoursWorked)));
            Assert.IsTrue(controller.ModelState.ContainsKey(nameof(hourlyRate)));
        }

        // Test: Invalid claim submission (File size exceeds limit)
        [TestMethod]
        public async Task SubmitClaim_FileSizeExceedsLimit_ReturnsModelError()
        {
            // Arrange
            var user = new ApplicationUser { Name = "John", Surname = "Doe" };

            _mockUserManager.Setup(um => um.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                            .ReturnsAsync(user);

            var controller = new LecturerController(_mockEnvironment.Object, _mockContext, _mockUserManager.Object);

            var mockFile = new Mock<IFormFile>();
            mockFile.Setup(f => f.Length).Returns(15 * 1024 * 1024);
            mockFile.Setup(f => f.FileName).Returns("largefile.pdf");

            // Act
            var result = await controller.SubmitClaim(5, 50, "File too large", mockFile.Object) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsTrue(controller.ModelState.ContainsKey(""));
        }

        // Test: Invalid claim submission (Invalid file type)
        [TestMethod]
        public async Task SubmitClaim_InvalidFileType_ReturnsModelError()
        {
            // Arrange
            var user = new ApplicationUser { Name = "John", Surname = "Doe" };

            _mockUserManager.Setup(um => um.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                            .ReturnsAsync(user);

            var controller = new LecturerController(_mockEnvironment.Object, _mockContext, _mockUserManager.Object);

            var mockFile = new Mock<IFormFile>();
            var content = "Fake file content";
            var fileName = "test.exe"; // Invalid file type
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            mockFile.Setup(_ => _.OpenReadStream()).Returns(ms);
            mockFile.Setup(_ => _.FileName).Returns(fileName);
            mockFile.Setup(_ => _.Length).Returns(ms.Length);

            double hoursWorked = 5;
            double hourlyRate = 50;

            // Act
            var result = await controller.SubmitClaim(hoursWorked, hourlyRate, "Invalid file type", mockFile.Object) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsTrue(controller.ModelState.ContainsKey(""));
            Assert.AreEqual("Only .pdf, .jpg, and .png files are allowed.", controller.ModelState[""].Errors[0].ErrorMessage);
        }

        //Test: Tracking status of a claim
        [TestMethod]
        public void TrackStatus_ReturnsClaimsForLoggedInUser()
        {
            // Arrange
            var userId = "user-id";
            var user = new ApplicationUser { Id = userId, Name = "John", Surname = "Doe" };

            _mockUserManager.Setup(um => um.GetUserId(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                            .Returns(userId);

            // Add claims to the in-memory database with all required properties
            var claims = new List<Claim>
    {
        new Claim { LecturerId = userId, HoursWorked = 10, HourlyRate = 20, Status = "Pending", DocumentPath = "/uploads/doc1.pdf", LecturerFullName = "John Doe", Notes = "Test note 1" },
        new Claim { LecturerId = userId, HoursWorked = 5, HourlyRate = 15, Status = "Approved", DocumentPath = "/uploads/doc2.pdf", LecturerFullName = "John Doe", Notes = "Test note 2" },
        new Claim { LecturerId = "other-user-id", HoursWorked = 8, HourlyRate = 25, Status = "Pending", DocumentPath = "/uploads/doc3.pdf", LecturerFullName = "Jane Smith", Notes = "Test note 3" }
    };

            _mockContext.Claims.AddRange(claims);
            _mockContext.SaveChanges();

            var controller = new LecturerController(_mockEnvironment.Object, _mockContext, _mockUserManager.Object);

            // Act
            var result = controller.TrackStatus() as ViewResult;
            var model = result?.Model as List<Claim>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Count);
            Assert.IsTrue(model.All(c => c.LecturerId == userId));
        }





        // Helper method to mock UserManager
        private static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            return new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
        }
    }
}