using EmployeeTitles.DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EmployeeTitles.BLL.Tests.TitleService
{
    [TestClass()]
    public class DeleteByIdAsyncTests
    {
        [TestMethod()]
        public async Task WhenNoSuchTitle_ReturnFalse()
        {
            Mock<ITitleRepository> titleRepository = new Mock<ITitleRepository>();
            titleRepository.Setup(f => f.GetTitleEmployeesCountAsync(It.IsAny<int>())).Returns(Task.FromResult(0));
            titleRepository.Setup(f => f.DeleteByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(false));

            var titleService = new EmployeeTitles.BLL.Services.TitleService(titleRepository.Object);
            var result = await titleService.DeleteByIdAsync(0);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public async Task WhenTitleAssigned_ReturnFalse()
        {
            Mock<ITitleRepository> titleRepository = new Mock<ITitleRepository>();
            titleRepository.Setup(f => f.GetTitleEmployeesCountAsync(It.IsAny<int>())).Returns(Task.FromResult(1));
            titleRepository.Setup(f => f.DeleteByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(true));

            var titleService = new EmployeeTitles.BLL.Services.TitleService(titleRepository.Object);
            var result = await titleService.DeleteByIdAsync(1);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public async Task WhenTitleNotAssignedAndExists_ReturnTrue()
        {
            Mock<ITitleRepository> titleRepository = new Mock<ITitleRepository>();
            titleRepository.Setup(f => f.GetTitleEmployeesCountAsync(It.IsAny<int>())).Returns(Task.FromResult(0));
            titleRepository.Setup(f => f.DeleteByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(true));

            var titleService = new EmployeeTitles.BLL.Services.TitleService(titleRepository.Object);
            var result = await titleService.DeleteByIdAsync(1);

            Assert.IsTrue(result);
        }
    }
}
