using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project01_MVCQuestionBank.Models
{
    public class Choice
    {
        [Key][Required] public int Id { get; set; }
        public int QuestionId { get; set; }
        [Range(1, 4)] public int Index { get; set; }
        [Required] public string Title { get; set; }
        public bool IsCorrect { get; set; }


        [ForeignKey("QuestionId")][Required] public Question Question { get; set; }

    }
}
