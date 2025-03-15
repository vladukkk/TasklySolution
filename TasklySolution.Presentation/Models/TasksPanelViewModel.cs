using BusinessLogic.DTOs.Quotes;
using BusinessLogic.DTOs.Tag;
using BusinessLogic.DTOs.Task;

namespace TasklySolution.Presentation.Models
{
    public class TasksPanelViewModel
    {
        public string? UserName { get; set; }
        public List<TaskDTO>? Tasks { get; set; }
        public List<TagDTO>? Tags {get; set;}
        public List<QuoteDTO>? Quotes { get; set; }
    }
}
