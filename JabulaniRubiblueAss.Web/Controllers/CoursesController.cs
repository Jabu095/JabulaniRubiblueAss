using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JabulaniRubiblueAss.Repository.Data;
using JabulaniRubiblueAss.Repository.ORM;
using JabulaniRubiblueAss.Service.Course;
using JabulaniRubiblueAss.Helper.Course;

namespace JabulaniRubiblueAss.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService CourseService;

        public CoursesController(ICourseService courseService)
        {
            CourseService = courseService;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await CourseService.GetAllAsync());
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var course = await CourseService.GetByIdAsync((int)id);
                if (course == null)
                {
                    return NotFound();
                }
                return View(course);
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseName,StartDate,EndDate")] CourseViewModel course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (isStartDateAhead(course.StartDate, course.EndDate))
                    {
                        var result = await CourseService.InsertAsync(MapCoures(course));
                    }
                    return RedirectToAction(nameof(Index));
                }
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var course = await CourseService.GetByIdAsync((int)id);
                if (course == null)
                {
                    return NotFound();
                }
                return View(course);
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseName,StartDate,EndDate")] CourseViewModel course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var result = await CourseService.UpdateAsync(MapCoures(course, id));
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CourseExists(id))
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
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var course = await CourseService.GetByIdAsync((int)id);
                if (course == null)
                {
                    return NotFound();
                }

                return View(course);
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var course = await CourseService.GetByIdAsync(id);
                var result = CourseService.DeleteAsync(course);
            }catch(Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            var course = CourseService.GetByIdAsync(id).Result;
            return course == null ? false : true;
        }

        #region "private methods"
        private Repository.ORM.Course MapCoures(CourseViewModel course)
        {
            return new Repository.ORM.Course { CourseName = course.CourseName, EndDate = course.EndDate, StartDate = course.StartDate };
        }

        private Repository.ORM.Course MapCoures(CourseViewModel course, int id)
        {
            return new Repository.ORM.Course { CourseId = id, CourseName = course.CourseName, EndDate = course.EndDate, StartDate = course.StartDate };
        }

        private bool isStartDateAhead(DateTime startDate, DateTime endDate)
        {
            var _dateCompare = DateTime.Compare(startDate, endDate);

            return _dateCompare < 1 ? true : false;
        }
        #endregion
    }
}
