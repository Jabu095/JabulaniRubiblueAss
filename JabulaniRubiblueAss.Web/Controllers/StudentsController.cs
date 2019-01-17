using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JabulaniRubiblueAss.Service.Student;
using JabulaniRubiblueAss.Helper.Student;

namespace JabulaniRubiblueAss.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService StudentService;

        public StudentsController(IStudentService studentService)
        {
            StudentService = studentService;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await StudentService.GetAllAsync());
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var student = await StudentService.GetByIdAsync((int)id);
                if (student == null)
                {
                    return NotFound();
                }

                return View(student);
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,Surname,EmailAddress,IDNumber")] StudentViewModel student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await StudentService.InsertAsync(new Repository.ORM.Student { EmailAddress = student.EmailAddress, FirstName = student.FirstName, IDNumber = student.IDNumber, Surname = student.Surname });
                    return RedirectToAction(nameof(Index));
                }
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var student = await StudentService.GetByIdAsync((int)id);
                if (student == null)
                {
                    return NotFound();
                }
                return View(student);
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,Surname,EmailAddress,IDNumber")] StudentViewModel student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var result = StudentService.UpdateAsync(new Repository.ORM.Student { EmailAddress = student.EmailAddress, Surname = student.Surname, FirstName = student.FirstName, IDNumber = student.IDNumber, StudentId = id });
                    }
                    catch (Exception)
                    {

                    }
                    return RedirectToAction(nameof(Index));
                }
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var student = await StudentService.GetByIdAsync((int)id);
                if (student == null)
                {
                    return NotFound();
                }

                return View(student);
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var student = await StudentService.GetByIdAsync(id);
                var result = StudentService.DeleteAsync(student);
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        //private bool StudentExists(int id)
        //{
        //    return _context.Students.Any(e => e.StudentId == id);
        //}
    }
}
