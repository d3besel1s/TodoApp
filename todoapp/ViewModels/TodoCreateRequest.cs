using todoapp.Models;

namespace todoapp.ViewModels
{
	public class TodoCreateRequest
	{
		public string Description { get; set; }
        public TodoCategory Category { get; set; }
    }
}
