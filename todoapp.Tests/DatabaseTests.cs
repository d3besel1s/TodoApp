using NUnit.Framework;
using todoapp.Models;

namespace Tests
{
	public class DatabaseTests
	{
		private TodoDatabase db;
        private int testId;

		[SetUp]
		public void Setup()
		{
			db = new TodoDatabase(addDefaults: false);
            testId = 1;
        }

		[Test]
		public void TestGetAll()
		{
			// the database should start out empty
			Assert.IsEmpty(db.GetAllTodos());
		}

        [Test]
        public void TestAddToDo()
        {
            var newItem = new TodoItem()
            {
                Description = "Finish assignment",
                Category = TodoCategory.University,
                TodoItemId = testId
            };

            db.AddTodo(newItem);

            var itemFromDb = db.GetTodoById(testId);

            Assert.AreEqual(itemFromDb.TodoItemId, newItem.TodoItemId);
            Assert.AreEqual(itemFromDb.Category, newItem.Category);
            Assert.AreEqual(itemFromDb.Description, newItem.Description);
        }

        [Test]
        public void TestEditCategory()
        {
            var item = db.GetTodoById(testId);
            var newCategory = TodoCategory.Work;

            item.Category = newCategory;

            db.EditCategory(item, newCategory);

            var itemFromDb = db.GetTodoById(item.TodoItemId);

            Assert.AreEqual(itemFromDb.Category, item.Category);
        }

        [Test]
        public void TestDeleteById()
        {
            db.DeleteById(testId);

            var item = db.GetTodoById(testId);

            Assert.IsNull(item);
        }


    }
}