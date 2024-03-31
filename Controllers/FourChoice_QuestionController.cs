using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project01_MVCQuestionBank.Data;
using Project01_MVCQuestionBank.Models;

namespace Project01_MVCQuestionBank.Controllers
{
    public class FourChoice_QuestionController : Controller
    {
        private readonly Project01_MVCQuestionBankContext _context;
        private DbSet<FourChoice_Question> FourChoice_Questions;

        public FourChoice_QuestionController(Project01_MVCQuestionBankContext context)
        {
            FourChoice_Question fourChoice_Question = new FourChoice_Question();
            _context = context;
            for (int i = 0; i < _context.Questions.Count(); i++)
            {
                fourChoice_Question.Question = _context.Questions.ElementAt(i);
                fourChoice_Question.Choice01 = _context.Choices.Where(choice => choice.Question == fourChoice_Question.Question).Where(choice => choice.Index == 1).First();
                fourChoice_Question.Choice02 = _context.Choices.Where(choice => choice.Question == fourChoice_Question.Question).Where(choice => choice.Index == 2).First();
                fourChoice_Question.Choice03 = _context.Choices.Where(choice => choice.Question == fourChoice_Question.Question).Where(choice => choice.Index == 3).First();
                fourChoice_Question.Choice04 = _context.Choices.Where(choice => choice.Question == fourChoice_Question.Question).Where(choice => choice.Index == 4).First();
                fourChoice_Question.CorrectChoice = fourChoice_Question.Question.Choices.Where(choice => choice.IsCorrect).First();
                fourChoice_Question.Reference = fourChoice_Question.Question.Reference;
                fourChoice_Question.Subject = fourChoice_Question.Question.Subject;
                fourChoice_Question.Section = fourChoice_Question.Question.Subject.Section;
                fourChoice_Question.Chapter = fourChoice_Question.Question.Subject.Section.Chapter;
                fourChoice_Question.Semester = fourChoice_Question.Question.Subject.Section.Chapter.Semester;
                FourChoice_Questions.Add(fourChoice_Question);
            }

        }

        // GET: FourChoice_Question
        public async Task<IActionResult> Index()
        {
            return FourChoice_Questions != null ?
                        View(await FourChoice_Questions.ToListAsync()) :
                        Problem("Entity set 'FourChoice_Questions'  is null.");
        }

        // GET: FourChoice_Question/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || FourChoice_Questions == null)
            {
                return NotFound();
            }

            var fourChoice_Question = await FourChoice_Questions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fourChoice_Question == null)
            {
                return NotFound();
            }

            return View(fourChoice_Question);
        }

        // GET: FourChoice_Question/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FourChoice_Question/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,SemesterTitle,ChapterTitle,SectionTitle,SubjectTitle,QuestionTitle,Choice01Title,Choice02Title,Choice03Title,Choice04Title,CorrectChoiceIndex,ReferenceTitle")]
            FourChoice_Question fourChoice_Question
            )
        {
            if (ModelState.IsValid)
            {
                _context.Questions.Add(fourChoice_Question.Question);
                _context.Choices.Add(fourChoice_Question.Choice01);
                _context.Choices.Add(fourChoice_Question.Choice02);
                _context.Choices.Add(fourChoice_Question.Choice03);
                _context.Choices.Add(fourChoice_Question.Choice04);
                if (!_context.References.Contains(fourChoice_Question.Reference)) _context.References.Add(fourChoice_Question.Reference);
                if (!_context.Subjects.Contains(fourChoice_Question.Subject)) _context.Subjects.Add(fourChoice_Question.Subject);
                if (!_context.Sections.Contains(fourChoice_Question.Section)) _context.Sections.Add(fourChoice_Question.Section);
                if (!_context.Chapters.Contains(fourChoice_Question.Chapter)) _context.Chapters.Add(fourChoice_Question.Chapter);
                if (!_context.Semesters.Contains(fourChoice_Question.Semester)) _context.Semesters.Add(fourChoice_Question.Semester);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fourChoice_Question);
        }

        // GET: FourChoice_Question/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || FourChoice_Questions == null)
            {
                return NotFound();
            }

            var fourChoice_Question = await FourChoice_Questions.FindAsync(id);
            if (fourChoice_Question == null)
            {
                return NotFound();
            }
            return View(fourChoice_Question);
        }

        // POST: FourChoice_Question/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SemesterTitle,ChapterTitle,SectionTitle,SubjectTitle,QuestionTitle,Choice01Title,Choice02Title,Choice03Title,Choice04Title,CorrectChoiceIndex,ReferenceTitle")] FourChoice_Question fourChoice_Question)
        {
            if (id != fourChoice_Question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fourChoice_Question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FourChoice_QuestionExists(fourChoice_Question.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fourChoice_Question);
        }

        // GET: FourChoice_Question/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || FourChoice_Questions == null)
            {
                return NotFound();
            }

            var fourChoice_Question = await FourChoice_Questions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fourChoice_Question == null)
            {
                return NotFound();
            }

            return View(fourChoice_Question);
        }

        // POST: FourChoice_Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (FourChoice_Questions == null)
            {
                return Problem("Entity set 'Project01_MVCQuestionBankContext.FourChoice_Question'  is null.");
            }
            var fourChoice_Question = await FourChoice_Questions.FindAsync(id);
            if (fourChoice_Question != null)
            {
                FourChoice_Questions.Remove(fourChoice_Question);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FourChoice_QuestionExists(int id)
        {
            return (FourChoice_Questions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
