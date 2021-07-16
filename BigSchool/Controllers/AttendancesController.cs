﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BigSchool.Models;
using Microsoft.AspNet.Identity;

namespace BigSchool.Controllers
{
    public class AttendancesController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Attend(Course attendanceDto)
        {
            var userID = User.Identity.GetUserId();
            BigSchoolContext context = new BigSchoolContext();
            if (context.Attendance.Any(p => p.Attendee == userID && p.CourseId ==
            attendanceDto.Id))
            {

                // xóa thông tin khóa học đã đăng ký tham gia trong bảng Attendances
                context.Attendance.Remove(context.Attendance.SingleOrDefault(p =>
                p.Attendee == userID && p.CourseId == attendanceDto.Id));
                context.SaveChanges();
                return Ok("cancel");
            }
            var attendance = new Attendance()
            {
                CourseId = attendanceDto.Id,
                Attendee =
            User.Identity.GetUserId()
            };
            context.Attendance.Add(attendance);
            context.SaveChanges();
            return Ok();
        }
    }
}
