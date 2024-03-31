using System.ComponentModel.DataAnnotations;

namespace Project01_MVCQuestionBank.Models
{
    public class Reference
    {
        [Key] public int Id { get; set; }
        public int QuestionId { get; set; }

        [Required] public string Title { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

    }
}
