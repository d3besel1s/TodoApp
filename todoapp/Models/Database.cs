using System;
using System.Collections.Generic;
using System.Linq;

namespace todoapp.Models
{
    /**
	 * This class represents the database that stores all data that is needed for the todoapp. Normally, a proper database
	 * would be used, but setting one up would be outside the scope of this assignment. So instead, we have this TodoDatabase
	 * class that is merely pretending to be a database.
	 */
    public class TodoDatabase
	{
		private List<TodoItem> AllTodoItems;

        /// <summary>
        /// Constructor for the database
        /// </summary>
        /// <param name="addDefaults">Indicates whether to add the default todo items</param>
		public TodoDatabase(bool addDefaults = true)
		{
			if(addDefaults)
			{
				var id = 1;
				AllTodoItems = new List<TodoItem>()
				{
					new TodoItem(id++, "Implement the 'Completed' button"), //done
					new TodoItem(id++, "Implement the 'Delete' button"),
					new TodoItem(id++, "Make the counter at the top of the page show the correct value"),
					new TodoItem(id++, "Only show non-completed Todos in the overview"),
					new TodoItem(id++, "Add a class 'TodoCategory' to the database"),
					new TodoItem(id++, "Add some default categories to the database"),
					new TodoItem(id++, "For the to-do items in the overview, show which category they're in (if any)"),
					new TodoItem(id++, "Change the 'New to-do' feature to allow setting a category on the todo"),
					new TodoItem(id++, "Allow filtering the to-do list on a category"),
					new TodoItem(id++, "Implement the unit tests"),
				};
			}
			else
			{
				AllTodoItems = new List<TodoItem>();
			}
		}

        /// <summary>
        /// Gets all todo items
        /// </summary>
        /// <param name="onlyIncomplete">indicates whether the returned todo item is completed or not (default: false)</param>
        /// <returns>list of todo items</returns>
        public List<TodoItem> GetAllTodos(bool onlyIncomplete = false)
		{
            return onlyIncomplete ? AllTodoItems.Where(ti => !ti.IsCompleted).ToList() : AllTodoItems;
		}

        /// <summary>
        /// Gets todo item by id
        /// </summary>
        /// <param name="id">id of the todo item</param>
        /// <returns>todo item object with given id</returns>
        public TodoItem GetTodoById(int id)
		{
			return AllTodoItems.FirstOrDefault(x => x.TodoItemId == id);
		}

        /// <summary>
        /// Generates id for the todo items and adds to the todo item list
        /// </summary>
        /// <param name="newTodo">new todo item</param>
		public void AddTodo(TodoItem newTodo)
		{
			// normally, it is the job of the database to generate unique identifiers for each object.
			// but in this case we have to do it manually
			var id = 1;
			if(AllTodoItems.Any())
			{
				id = AllTodoItems.Max(x => x.TodoItemId) + 1;
			}
			newTodo.TodoItemId = id;
			AllTodoItems.Add(newTodo);
		}

        /// <summary>
        /// Deletes the todo item
        /// </summary>
        /// <param name="id">id of the todo item</param>
        public void DeleteById(int id) {
            var todo = GetTodoById(id);
            if (todo != null)
                AllTodoItems.Remove(todo);
        }

        /// <summary>
        /// Edits the category of the todo item
        /// </summary>
        /// <param name="item">Todo item</param>
        /// <param name="newCategory">New category for the todo item</param>
        public void EditCategory(TodoItem item, TodoCategory newCategory)
        {
            throw new NotImplementedException();
        }
    }
}
