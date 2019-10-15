namespace todoapp.Models
{
	public class TodoItem
	{
		public int TodoItemId { get; set; }

		public string Description { get; set; }
		public bool IsCompleted { get; set; }

        public TodoCategory Category { get; set; }

		public TodoItem() { }

		public TodoItem(int id, string description)
		{
			this.TodoItemId = id;
			this.Description = description;
		}
	}
}
