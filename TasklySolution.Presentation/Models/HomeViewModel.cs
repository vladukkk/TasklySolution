using BusinessLogic.DTOs;
using BusinessLogic.DTOs.Priority;
using BusinessLogic.DTOs.Tag;
using BusinessLogic.DTOs.User;

namespace TasklySolution.Presentation.Models
{
    public class HomeViewModel
    {
        public UserDTO? User { get; set; }
        public UserStatsDTO? UserStats { get; set; }
    }
}
