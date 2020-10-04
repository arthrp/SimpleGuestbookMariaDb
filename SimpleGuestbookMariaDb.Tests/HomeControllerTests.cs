using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SimpleGuestbookMariaDb.Controllers;
using SimpleGuestbookMariaDb.Dto;
using SimpleGuestbookMariaDb.Models;
using SimpleGuestbookMariaDb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Assert.True(result.GetType() == typeof(ViewResult));

            var typedRes = result as ViewResult;
            Assert.True(typedRes.ViewData.Model.GetType().IsAssignableFrom(typeof(GuestbookViewModel)));
            var typedModel = typedRes.ViewData.Model as GuestbookViewModel;

            Assert.True(typedModel.AllPosts.Count == 2);
            Assert.True(typedModel.AllPosts.Where(p => p.Username == "UserOne").Count() == 1);
            Assert.True(typedModel.AllPosts.Where(p => p.Username == "UserTwo").Count() == 1);

            Assert.True(typedModel.AllPosts.Where(p => p.Posttext == "Hello").Count() == 1);
            Assert.True(typedModel.AllPosts.Where(p => p.Posttext == "Hello!").Count() == 1);

            Assert.True(typedModel.AllPosts.Where(p => p.Id == 1).Count() == 1);
            Assert.True(typedModel.AllPosts.Where(p => p.Id == 2).Count() == 1);

            Assert.True(typedModel.AllPosts.Where(p => p.CreatedOn == DateTime.Parse("2020-01-03 11:00:00")).Count() == 1);
            Assert.True(typedModel.AllPosts.Where(p => p.CreatedOn == DateTime.Parse("2020-01-05 11:00:00")).Count() == 1);
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
