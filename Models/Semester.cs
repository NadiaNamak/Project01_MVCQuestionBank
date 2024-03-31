using System.ComponentModel.DataAnnotations;

namespace Project01_MVCQuestionBank.Models
{
    public class Semester
    {
        [Key] public int Id { get; set; }
        public int ChapterId { get; set; }
        //public int FourChoice_QuestionId { get; set; }

        [Required] public string Title { get; set; }
        public virtual ICollection<Chapter> Chapters { get; }
        //[Required] public virtual ICollection<FourChoice_Question> FourChoice_Questions { get; set; }

    }
}