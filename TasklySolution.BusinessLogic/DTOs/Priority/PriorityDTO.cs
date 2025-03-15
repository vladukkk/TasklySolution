using BusinessLogic.Contracts;

namespace BusinessLogic.DTOs.Priority
{
    public class PriorityDTO : IPriority
    { 
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string ColorHash { get; set; } = null!;
    }
}
