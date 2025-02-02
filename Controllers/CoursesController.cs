﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using traningday2.Models;

namespace traningday2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(
        SchoolContext _schoolContext
        ) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_schoolContext.Courses.AsNoTracking());
        }

        [HttpPost]
        public IActionResult Post(Course course)
        {
            _schoolContext.Courses.Add(course);
            _schoolContext.SaveChanges();
            return Ok(course);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Course course)
        {
            var courseInDb = _schoolContext.Courses.Find(id);
            if (courseInDb == null) return NotFound();
            courseInDb.Title = course.Title;
            courseInDb.Credits = course.Credits;
            _schoolContext.Courses.Update(course);
            _schoolContext.SaveChanges();
            return Ok(course);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = _schoolContext.Courses.Find(id);
            _schoolContext.Courses.Remove(course);
            _schoolContext.SaveChanges();
            return Ok(course);
        }
    }
}
