using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TaskManager.DLL.DBContext;
using TaskManager.DLL.Interfaces;
using TaskManager.DLL.Models;
using TaskManager.DLL.UnitOfWork;

namespace TaskManager.Tests.Repositories
{
    [TestFixture]
    public class StageRepositoryTests
    {
        TaskManagerContext taskManagerContext;
        IUnitOfWork unitOfWork;

        [OneTimeSetUp]
        public void SetUp()
        {
            var option = new DbContextOptionsBuilder<TaskManagerContext>();
            option.UseSqlServer("Server = DESKTOP-5S77NGN; Database = TaskManager; Trusted_Connection = True;");
            taskManagerContext = new TaskManagerContext(option.Options);
            unitOfWork = new UnitOfWork(taskManagerContext);
        }

        [Test]
        public void Create_Stage_When_create_Then_result_is_in_dbSet()
        {
            var id = unitOfWork.Stages.Create(new Stage()
            {
                Name = "123",
                Description = "Description for \"123\""
            });
            Assert.IsNotNull(taskManagerContext.Stages.Find(id));
            Assert.AreEqual(unitOfWork.Stages.GetById(id).Id, id);
            Assert.AreEqual(unitOfWork.Stages.GetById(id).Name, "123");
            Assert.AreEqual(unitOfWork.Stages.GetById(id).Description, "Description for \"123\"");
            unitOfWork.Stages.DeleteById(id);
        }

        [Test]
        public void Get_Stage_When_get_Then_results_are_equals()
        {
            Assert.AreEqual(unitOfWork.Stages.Get().Count, 0);
            var id1 = unitOfWork.Stages.Create(new Stage()
            {
                Name = "123",
                Description = "Description for \"123\""
            });
            Assert.AreEqual(unitOfWork.Stages.Get().Count, 1);
            Assert.AreEqual(unitOfWork.Stages.GetById(id1).Id, id1);
            Assert.AreEqual(unitOfWork.Stages.GetById(id1).Name, "123");
            Assert.AreEqual(unitOfWork.Stages.GetById(id1).Description, "Description for \"123\"");
            var id2 = unitOfWork.Stages.Create(new Stage()
            {
                Name = "123",
                Description = "Description for \"123\""
            });
            Assert.AreEqual(unitOfWork.Stages.Get().Count, 2);
            Assert.AreEqual(unitOfWork.Stages.GetById(id1).Id, id1);
            Assert.AreEqual(unitOfWork.Stages.GetById(id1).Name, "123");
            Assert.AreEqual(unitOfWork.Stages.GetById(id1).Description, "Description for \"123\"");
            Assert.AreEqual(unitOfWork.Stages.GetById(id2).Id, id2);
            Assert.AreEqual(unitOfWork.Stages.GetById(id2).Name, "123");
            Assert.AreEqual(unitOfWork.Stages.GetById(id2).Description, "Description for \"123\"");
            unitOfWork.Stages.DeleteById(id1);
            unitOfWork.Stages.DeleteById(id2);
        }

        [Test]
        public void GetById_Stage_When_get_Then_results_are_equals()
        {
            var id = unitOfWork.Stages.Create(new Stage()
            {
                Name = "123",
                Description = "Description for \"123\""
            });
            Assert.AreEqual(unitOfWork.Stages.GetById(id).Id, id);
            Assert.AreEqual(unitOfWork.Stages.GetById(id).Name, "123");
            Assert.AreEqual(unitOfWork.Stages.GetById(id).Description, "Description for \"123\"");
            unitOfWork.Stages.DeleteById(id);
        }

        [Test]
        public void Delete_Stage_When_delete_Then_dbSet_is_empty()
        {
            var id = unitOfWork.Stages.Create(new Stage()
            {
                Name = "123",
                Description = "Description for \"123\""
            });
            unitOfWork.Stages.Delete(unitOfWork.Stages.GetById(id));
            Assert.IsNull(taskManagerContext.Stages.Find(id));
        }

        [Test]
        public void DeleteById_Stage_When_delete_Then_dbSet_is_empty()
        {
            var id = unitOfWork.Stages.Create(new Stage()
            {
                Name = "123",
                Description = "Description for \"123\""
            });
            unitOfWork.Stages.DeleteById(id);
            Assert.IsNull(taskManagerContext.Stages.Find(id));
        }

        [Test]
        public void Update_Stage_When_update_Then_results_are_equals()
        {
            var id = unitOfWork.Stages.Create(new Stage()
            {
                Name = "123",
                Description = "Description for \"123\""
            });
            unitOfWork.Stages.Update(id, new Stage()
            {
                Name = "321",
                Description = "Description for \"321\""
            });
            var tmp = unitOfWork.Stages.GetById(id);
            Assert.AreEqual(tmp.Id, id);
            Assert.AreEqual(tmp.Name, "321");
            Assert.AreEqual(tmp.Description, "Description for \"321\"");
            unitOfWork.Stages.DeleteById(id);
        }

        [Test]
        public void UpdateStageName_Stage_When_update_Then_results_are_equals()
        {
            var id = unitOfWork.Stages.Create(new Stage()
            {
                Name = "123",
                Description = "Description for \"123\""
            });
            unitOfWork.Stages.UpdateStageName(id, "321");
            var tmp = unitOfWork.Stages.GetById(id);
            Assert.AreEqual(tmp.Id, id);
            Assert.AreEqual(tmp.Name, "321");
            Assert.AreEqual(tmp.Description, "Description for \"123\"");
            unitOfWork.Stages.DeleteById(id);
        }

        [Test]
        public void UpdateStageDescription_Stage_When_update_Then_results_are_equals()
        {
            var id = unitOfWork.Stages.Create(new Stage()
            {
                Name = "123",
                Description = "Description for \"123\""
            });
            unitOfWork.Stages.UpdateStageDescription(id, "Description for \"321\"");
            var tmp = unitOfWork.Stages.GetById(id);
            Assert.AreEqual(tmp.Id, id);
            Assert.AreEqual(tmp.Name, "123");
            Assert.AreEqual(tmp.Description, "Description for \"321\"");
            unitOfWork.Stages.DeleteById(id);
        }
    }
}