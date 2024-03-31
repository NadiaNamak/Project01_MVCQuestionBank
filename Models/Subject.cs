using System.ComponentModel.DataAnnotations;


namespace Project01_MVCQuestionBank.Models
{
    public class Subject
    {        
        [Key] public int Id { get; set; }
        public int QuestionId { get; set; }
        //public int FourChoice_QuestionId { get; set; }

        [Required] public string Title { get; set; }
        public Section Section { get; set; }
        public virtual ICollection<Question> Questions { get;}

    }
}
