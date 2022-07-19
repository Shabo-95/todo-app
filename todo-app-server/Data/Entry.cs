using System.ComponentModel.DataAnnotations;

namespace todo_app_server.Data
{
    internal sealed class Entry
    {
        [Key]
        public int TodoID { get; set; }

        [Required]
        [MinLength(10)]
        public string TodoTitel { get; set; } = string.Empty;

        [Required]
        public bool TodoIsFinished { get; set; } = false;
    }
}