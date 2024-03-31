using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project01_MVCQuestionBank.Models;

namespace Project01_MVCQuestionBank.Data
{
    public class Project01_MVCQuestionBankContext : DbContext
    {
        public Project01_MVCQuestionBankContext (DbContextOptions<Project01_MVCQuestionBankContext> options)
            : base(options)
        {
        }

        public DbSet<Project01_MVCQuestionBank.Models.Question> Questions { get; set; } = default!;
        public DbSet<Project01_MVCQuestionBank.Models.Choice> Choices { get; set; } = default!;
        public DbSet<Project01_MVCQuestionBank.Models.Reference> References { get; set; } = default!;
        public DbSet<Project01_MVCQuestionBank.Models.Subject> Subjects { get; set; } = default!;
        public DbSet<Project01_MVCQuestionBank.Models.Section> Sections { get; set; } = default!;
        public DbSet<Project01_MVCQuestionBank.Models.Chapter> Chapters { get; set; } = default!;
        public DbSet<Project01_MVCQuestionBank.Models.Semester> Semesters { get; set; } = default!;


    }
}
