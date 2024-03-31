using System.ComponentModel.DataAnnotations;

namespace Project01_MVCQuestionBank.Models
{
    public class FourChoice_Question
    {
        [Key] public int Id { get; set; }
        [Required]
        public string SemesterTitle
        {
            get
            {
                return SemesterTitle;
            }
            set
            {
                SemesterTitle = Semester.Title;
                SemesterTitle = value;
            }
        }
        [Required]
        public string ChapterTitle
        {
            get
            {
                return ChapterTitle;
            }
            set
            {
                ChapterTitle = Chapter.Title;
                ChapterTitle = value;
            }
        }
        [Required]
        public string SectionTitle
        {
            get
            {
                return SectionTitle;
            }
            set
            {
                SectionTitle = Section.Title;
                SectionTitle = value;
            }
        }
        [Required]
        public string SubjectTitle
        {
            get
            {
                return SubjectTitle;
            }
            set
            {
                SubjectTitle = Subject.Title;
                SubjectTitle = value;
            }
        }

        [Required]
        public string QuestionTitle
        {
            get
            {
                return QuestionTitle;
            }
            set
            {
                QuestionTitle = Question.Title;
                QuestionTitle = value;
            }
        }

        [Required]
        public string Choice01Title
        {
            get
            {
                return Choice01Title;
            }
            set
            {
                Choice01Title = Choice01.Title;
                Choice01Title = value;
            }
        }
        [Required]
        public string Choice02Title
        {
            get
            {
                return Choice02Title;
            }
            set
            {
                Choice02Title = Choice02.Title;
                Choice02Title = value;
            }
        }
        [Required]
        public string Choice03Title
        {
            get
            {
                return Choice03Title;
            }
            set
            {
                Choice03Title = Choice03.Title;
                Choice03Title = value;
            }
        }
        [Required]
        public string Choice04Title
        {
            get
            {
                return Choice04Title;
            }
            set
            {
                Choice03Title = Choice03.Title;
                Choice03Title = value;
            }
        }

        [Range(1, 4)]
        public int CorrectChoiceIndex
        {
            get
            {
                return CorrectChoiceIndex;
            }
            set
            {
                CorrectChoiceIndex = CorrectChoice.Index;
                CorrectChoiceIndex = value;
            }
        }

        [Required]
        public string ReferenceTitle
        {
            get
            {
                return ReferenceTitle;
            }
            set
            {
                ReferenceTitle = Reference.Title;
                ReferenceTitle = value;
            }
        }


        public Question Question
        {
            get
            {
                return Question;
            }
            set
            {
                Question.Subject = Subject;
                Question.Title = QuestionTitle;
                Question.Choices.Add(Choice01);
                Question.Choices.Add(Choice02);
                Question.Choices.Add(Choice03);
                Question.Choices.Add(Choice04);
                Question.Reference = Reference;
                Question.CorrectChoiceIndex = CorrectChoiceIndex;
                Question = value;
            }
        }
        public Choice Choice01
        {
            get
            {
                return Choice01;
            }
            set
            {
                Choice01.Title = Choice01Title;
                Choice01.Question = Question;
                Choice01.Index = 1;
                Choice01 = value;
            }
        }
        public Choice Choice02
        {
            get
            {
                return Choice01;
            }
            set
            {
                Choice02.Title = Choice02Title;
                Choice02.Question = Question;
                Choice02.Index = 2;
                Choice02 = value;
            }
        }
        public Choice Choice03
        {
            get { return Choice03; }
            set
            {
                Choice03.Title = Choice03Title;
                Choice03.Question = Question;
                Choice03.Index = 3;
            }
        }
        public Choice Choice04
        {
            get { return Choice04; }
            set
            {
                Choice04.Title = Choice04Title;
                Choice04.Question = Question;
                Choice04.Index = 4;
                Choice03 = value;
            }
        }
        public Choice CorrectChoice
        {
            get { return CorrectChoice; }
            set
            {
                switch (CorrectChoiceIndex)
                {
                    case 1:
                        Choice01.IsCorrect = true; CorrectChoice = Choice01; break;
                    case 2:
                        Choice02.IsCorrect = true; CorrectChoice = Choice02; break;
                    case 3:
                        Choice03.IsCorrect = true; CorrectChoice = Choice03; break;
                    case 4:
                        Choice04.IsCorrect = true; CorrectChoice = Choice04; break;
                    default: CorrectChoice = Choice01; break;
                }
                CorrectChoice = value;
            }
        }
        public Reference Reference
        {
            get { return Reference; }
            set
            {
                Reference.Title = ReferenceTitle;
                Reference.Questions.Add(Question);
                Reference = value;
            }
        }

        public Subject Subject
        {
            get { return Subject; }
            set
            {
                Subject.Title = SubjectTitle;
                Subject.Section = Section;
                Subject.Questions.Add(Question);
                Subject = value;
            }
        }

        public Section Section
        {
            get { return Section; }
            set
            {
                Section.Title = SectionTitle;
                Section.Chapter = Chapter;
                Section.Subjects.Add(Subject);
                Section = value;
            }
        }
        public Chapter Chapter
        {
            get { return Chapter; }
            set
            {
                Chapter.Title = ChapterTitle;
                Chapter.Semester = Semester;
                Chapter.Sections.Add(Section);
                Chapter = value;
            }
        }
        public Semester Semester
        {
            get { return Semester; }
            set
            {
                Semester.Title = SemesterTitle;
                Semester.Chapters.Add(Chapter);
                Semester = value;
            }
        }
        public FourChoice_Question() { }

    }
}
