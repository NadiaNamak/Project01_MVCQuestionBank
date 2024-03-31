using System.ComponentModel.DataAnnotations;

namespace Project01_MVCQuestionBank.Models
{
    public class Chapter
    {
        [Key] public int Id { get; set; }
        public int SectionId { get; set; }

        [Required] public string Title { get; set; }
        public Semester Semester { get; set; }
        public virtual ICollection<Section> Sections { get; }

    }
}
