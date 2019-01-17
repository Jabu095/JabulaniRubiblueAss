using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JabulaniRubiblueAss.Repository.ORM;
using JabulaniRubiblueAss.Service.StudentCourse;
using JabulaniRubiblueAss.Service.Course;
using JabulaniRubiblueAss.Service.Student;
using JabulaniRubiblueAss.Helper.StudentCourse;

namespace JabulaniRubiblueAss.Web.Controllers
{
    public class StudentCoursesController : Controller
    {
        private readonly IStudentCourseService StudentCourseService;
        private readonly ICourseService CourseService;
        private readonly IStudentService StudentService;

        public StudentCoursesController(IStudentCourseService studentCourseService, 
                                        ICourseService courseService,
                                        IStudentService studentService)
        {
            StudentCourseService = studentCourseService;
            CourseService = courseService;
            StudentService = studentService;
        }

        // GET: StudentCourses
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await StudentCourseService.GetAllStudentCourses());

            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
            
        }

        // GET: StudentCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var studentCourse = await StudentService.GetStudentCourseByStudentId((int)id);
                if (studentCourse == null)
                {
                    return NotFound();
                }
                return View(studentCourse);
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        // GET: StudentCourses/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["CourseName"] = new SelectList(CourseService.GetAllAsync().Result, "CourseName", "CourseName");
                ViewData["StudentId"] = new SelectList(StudentService.GetAllAsync().Result, "StudentId", "StudentId");
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        // POST: StudentCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,StudentId,CourseName")] StudentCourseViewModel studentCourse)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var numberOfEnrolled = await StudentService.GetNumberOfCourse(studentCourse.StudentId);
                    if (numberOfEnrolled == 3)
                    {
                       
                        throw new Exception("maximum number of three Courses per student recheched");
                    }
                    var _course = await CourseService.GetCourseByName(studentCourse.CourseName);
                    if (_course == null)
                        throw new Exception("Course name not found");
                        
                    var result = await StudentCourseService.InsertAsync(new StudentCourse { CourseId = _course.CourseId, StudentId = studentCourse.StudentId });
                    return RedirectToAction(nameof(Index));
                }
                
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            ViewData["CourseName"] = new SelectList(CourseService.GetAllAsync().Result, "CourseName", "CourseName");
            ViewData["StudentId"] = new SelectList(StudentService.GetAllAsync().Result, "StudentId", "StudentId");
            return View(studentCourse);
        }

        // GET: StudentCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var studentCourse = await StudentCourseService.GetStudentByCourseId((int)id);
                if (studentCourse == null)
                {
                    return NotFound();
                }
                ViewData["CourseName"] = new SelectList(CourseService.GetAllAsync().Result, "CourseName", "CourseName");
                ViewData["StudentId"] = new SelectList(StudentService.GetAllAsync().Result, "StudentId", "StudentId");
                return View(studentCourse);
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        // POST: StudentCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,StudentId,CourseName")] StudentCourseViewModel studentCourse)
        {
            try
            {
                if (id != studentCourse.CourseId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        var result = await StudentCourseService.UpdateAsync(new StudentCourse { StudentId = studentCourse.StudentId, CourseId = studentCourse.CourseId });
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!StudentCourseExists(studentCourse.CourseId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            ViewBag.error = "Record could not be added";
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                ViewData["CourseName"] = new SelectList(CourseService.GetAllAsync().Result, "CourseName", "CourseName");
                ViewData["StudentId"] = new SelectList(StudentService.GetAllAsync().Result, "StudentId", "StudentId");
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View(studentCourse);
        }

        // GET: StudentCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var studentCourse = await StudentCourseService.GetStudentByCourseId((int)id);
                if (studentCourse == null)
                {
                    return NotFound();
                }

                return View(studentCourse);
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        // POST: StudentCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var studentCourse = await StudentCourseService.GetStudentByCourseId(id);
                var result = StudentCourseService.DeleteAsync(studentCourse);
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        private bool StudentCourseExists(int id)
        {
            var _studentCourse = StudentCourseService.GetStudentByCourseId(id).Result;

            return _studentCourse == null ? false : true;
        }
    }
}
