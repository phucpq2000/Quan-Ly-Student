namespace QuanLyStudent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name ="Họ và tên")]
        public string Name { get; set; }
        [Display(Name = "Số tuổi")]
        public int? Age { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        [Display(Name = "Giới tính")]
        public string Sex { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ Email")]
        public string Email { get; set; }

        public int IdUser { get; set; }
        [Display(Name = "Chức vụ")]
        public int IdClass { get; set; }

        public virtual Class Class { get; set; }

        public virtual User User { get; set; }
    }
}
