using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrelloTestApi.Modal
{
    public class TaskModal
    {
        [Key]
        public int TaskId { get; set; }

        public string TaskTitle { get; set; } = String.Empty;

        public string TaskDesc { get; set; } = String.Empty;

        public string Status { get; set; } = String.Empty;

    }
}
