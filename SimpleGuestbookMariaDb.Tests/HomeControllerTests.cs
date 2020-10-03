using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SimpleGuestbookMariaDb.Controllers;
using SimpleGuestbookMariaDb.Dto;
using SimpleGuestbookMariaDb.Repositories;
using System;
using System.Collections.Generic;

namespace SimpleGuestbookMariaDb.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void IndexWorks()
        {
            var mockRepo = new Mock<IPostsRepository>();
            var mockLogger = new Mock<ILogger<HomeController>>();

            mockRepo.Setup(repo => repo.GetAll()).Returns(GetTestPosts());
            var controller = new HomeController(mockLogger.Object, mockRepo.Object);

            var result = controller.Index();
            Assert.IsTrue(result.GetType() == typeof(ViewResult));
        }

        private List<PostDto> GetTestPosts()
        {
            return new List<PostDto>()
            {
                new PostDto(){ Id = 1, CreatedOn = DateTime.Parse("2020-01-03 11:00:00"), Posttext = "Hello", Username = "UserOne"},
                new PostDto(){ Id = 2, CreatedOn = DateTime.Parse("2020-01-05 11:00:00"), Posttext = "Hello!", Username = "UserTwo"}
            };
        }
    }
}
