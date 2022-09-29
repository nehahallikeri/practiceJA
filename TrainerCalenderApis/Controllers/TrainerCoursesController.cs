using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainerCalenderApis;
using TrainerCalenderApis.Data;

namespace TrainerCalenderApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerCoursesController : ControllerBase
    {
        private readonly DataContext _context;

        public TrainerCoursesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TrainerCourses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainerCourse>>> GetTrainerCourses()
        {
            var trainerCourse = await _context.TrainerCourses.ToListAsync();
            foreach(var i in trainerCourse)
            {
              i.Course = _context.Courses.FirstOrDefault(x => x.Id == i.CourseId);

            }
            return trainerCourse;
        }

        // GET: api/TrainerCourses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainerCourse>> GetTrainerCourse(int id)
        {
            var trainerCourse = await _context.TrainerCourses.FindAsync(id);
            trainerCourse.Course =_context.Courses.FirstOrDefault(x => x.Id == trainerCourse.CourseId) ;
            trainerCourse.User = _context.Users.FirstOrDefault(x => x.ID == trainerCourse.UserId);

            Console.WriteLine(trainerCourse.Course);
            if (trainerCourse == null)
            {
                return NotFound();
            }

            return trainerCourse;
        }

        // PUT: api/TrainerCourses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainerCourse(int id, TrainerCourse trainerCourse)
        {
            if (id != trainerCourse.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainerCourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainerCourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TrainerCourses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainerCourse>> PostTrainerCourse(TrainerCourseDto trainerCourse)
        {
            TrainerCourse trainerCourse1 = new TrainerCourse();
            return trainerCourse1;
            //trainerCourse1.Id=
            //_context.TrainerCourses.Add(trainerCourse);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTrainerCourse", new { id = trainerCourse.Id }, trainerCourse);
        }

        // DELETE: api/TrainerCourses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainerCourse(int id)
        {
            var trainerCourse = await _context.TrainerCourses.FindAsync(id);
            if (trainerCourse == null)
            {
                return NotFound();
            }

            _context.TrainerCourses.Remove(trainerCourse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainerCourseExists(int id)
        {
            return _context.TrainerCourses.Any(e => e.Id == id);
        }
    }
}
