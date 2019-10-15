using todoapp.Models;

namespace todoapp.ViewModels
{
    public class TodoVM
    {
        public int TodoId { get; set; }
        public string Description { get; set; }
        public TodoCategory Category { get; set; }

    }
}
