using System.ComponentModel.DataAnnotations;

namespace Project01_MVCQuestionBank.Models
{
    public class Section
    {
        [Key] public int Id { get; set; }
        public int SubjectId { get; set; }
        //public int FourChoice_QuestionId { get; set; }


        [Required] public string Title { get; set; }
        public Chapter Chapter { get; set; }
        public virtual ICollection<Subject> Subjects { get;}

    }
}
