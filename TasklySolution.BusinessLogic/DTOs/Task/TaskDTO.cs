using BusinessLogic.Contracts;
using BusinessLogic.DTOs.Priority;
using BusinessLogic.DTOs.Tag;

namespace BusinessLogic.DTOs.Task
{
    public class TaskDTO : ITask
    {
        public Guid Id { get; set; }

        //public Guid UserId { get; set; }
        //public User User { get; set; }

        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public PriorityDTO Priority { get; set; } = null!;

        public List<TagDTO>? Tags { get; set; }
    }
}
