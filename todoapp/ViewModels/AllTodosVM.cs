using System.Collections.Generic;
using todoapp.Models;

namespace todoapp.ViewModels
{
	public class AllTodosVM
	{
		public List<TodoVM> Todos { get; set; }
		public int Count { get; set; }
        public TodoCategory SelectedCategory { get; set; }
	}
}
