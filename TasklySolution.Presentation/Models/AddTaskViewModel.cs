using BusinessLogic.DTOs.Priority;
using BusinessLogic.DTOs.Tag;

namespace TasklySolution.Presentation.Models
{
    public class AddTaskViewModel
    {
        public List<PriorityDTO>? Priorities { get; set; }
        public List<TagDTO>? Tags { get; set; }
    }
}
