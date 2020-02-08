using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Academy.Lib;
using Academy.Lib.Models;
using Common.Lib.Core.Context;
using Common.Lib.Core;
using Common.Lib.Infrastructure;

namespace AcademyWebApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AcademyDbContext _context;

        public StudentsController(AcademyDbContext context)
        {
            _context = context;

            //if (context.StudentSet.Count() == 0)
            //{
            //    var std1 = new Student();
            //    std1.Id = Guid.NewGuid();
            //    std1.Name = "Perico";

            //    var std2 = new Student();
            //    std2.Id = Guid.NewGuid();
            //    std2.Name = "Lola";

            //    context.StudentSet.Add(std1);
            //    context.StudentSet.Add(std2);

            //    context.SaveChanges();
            //}
        }

        // GET: api/Students
        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            var repo = Entity.DepCon.Resolve<IRepository<Student>>();
            return await repo.QueryAll().ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(Guid id)
        {
            var repo = Entity.DepCon.Resolve<IRepository<Student>>();
            var student = await repo.QueryAll().FirstOrDefaultAsync(x => x.Id == id);



            //var student = await _context.StudentSet.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        //  public async Task<IActionResult> PutStudent(Guid id, Student student)

        public async Task<SaveResult<Student>> PutStudent(Guid id, Student student)
        {
            //var repo = Entity.DepCon.Resolve<IRepository<Student>>();
            //var studentObject = await repo.QueryAll().FirstOrDefaultAsync(x => x.Id == id);

            return await Task.Run(() =>
            {
                return student.Save();
                //if (id != student.Id)
                //{
                //    return BadRequest();
                //}
                //else
                //{
                //    student.Save();
                //    return NoContent();
                //}
            });

            //_context.Entry(student).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!StudentExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<SaveResult<Student>> PostStudent(Student student)
        {
            return await Task.Run(() =>
            {
                return student.Save();
            });
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<DeleteResult<Student>> DeleteStudent(Guid id)

        //public async void DeleteStudent(Guid id)
        {
            //var student = await _context.StudentSet.FindAsync(id);
            //if (student == null)
            //{
            //    return NotFound();
            //}

            //_context.StudentSet.Remove(student);
            //await _context.SaveChangesAsync();

            //return student;
            //var repo = Entity.DepCon.Resolve<IRepository<Student>>();
            //var student = await repo.QueryAll().FirstOrDefaultAsync(x => x.Id == id);
            var repo = Entity.DepCon.Resolve<IRepository<Student>>();
            var student = await repo.QueryAll().FirstOrDefaultAsync(x => x.Id == id);


            return await Task.Run(() =>
            {
                //var repo = Entity.DepCon.Resolve<IRepository<Student>>();
                //var student = repo.QueryAll().FirstOrDefaultAsync(x => x.Id == id);
                //var repo = Entity.DepCon.Resolve<IRepository<Student>>();
                //Student student = repo.QueryAll().FirstOrDefault(x => x.Id == id);

                return student.Delete();


            });



        }

        private bool StudentExists(Guid id)
        {
            var repo = Entity.DepCon.Resolve<IRepository<Student>>();
            return repo.QueryAll().Any(x => x.Id == id);



            //return _context.StudentSet.Any(e => e.Id == id);
        }
    }
}
