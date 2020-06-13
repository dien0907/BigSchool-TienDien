using System;
using System.Collections.Generic;
using BigSchool.Models;
using System.ComponentModel.DataAnnotations;

namespace BigSchool.ViewModels
{
    public class CourseViewModel
    {
        [Required]
        [Display(Name ="Place")]
        public string Place { get; set; }
        [Required]
        [ValidDate]
        [Display(Name = "Date")]
        public string Date { get; set; }
        [Required]
        [ValidTime]
        [Display(Name = "Time")]
        public string Time { get; set; }
        [Required]
        [Display(Name = "Category")]
        public byte Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}