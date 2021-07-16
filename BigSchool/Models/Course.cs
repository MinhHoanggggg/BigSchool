namespace BigSchool.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        public Course()
        {
            Attendance = new HashSet<Attendance>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string LecturerId { get; set; }

        [Required]
        [StringLength(255)]
        public string Place { get; set; }

        public DateTime DateTime { get; set; }

        public int CategoryId { get; set; }

        public virtual ICollection<Attendance> Attendance { get; set; }

        public virtual Category Category { get; set; }
        public List<Category> ListCategory = new List<Category>();
        public string Name;
        public string LecturerName;

        public bool isLogin = false;
        public bool isShowFollow = false;
        public bool isShowGoing = false;

    }
}
