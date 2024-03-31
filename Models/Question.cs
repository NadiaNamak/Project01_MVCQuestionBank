using System.ComponentModel.DataAnnotations;

namespace Project01_MVCQuestionBank.Models
{
    public class Question
    {
        [Key] public int Id { get; set; }
        public int SubjectId { get; set; }
        public int ReferenceId { get; set; }
        [Required] public string Title { get; set; }
        [Required] public virtual ICollection<Choice> Choices { get; set; }
        [Range(1, 4)] public int CorrectChoiceIndex { get; set; }

        [DataType(DataType.DateTime)] public DateTime CreatedDate { get { return CreatedDate; } set { CreatedDate = DateTime.Now; } }

        [Required] public Subject Subject { get; set; }
        [Required] public Reference Reference { get; set; }

    }
}
