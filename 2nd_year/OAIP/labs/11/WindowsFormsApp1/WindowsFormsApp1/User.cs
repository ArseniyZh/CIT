using System;
using System.ComponentModel.DataAnnotations;

namespace WindowsFormsApp1
{
    public class User
    {
        public int Id { get; set; } // Primary key

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string RangeOfScience { get; set; }

        [Required]
        public DateTime DateOfFirstPost { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public static UserManager manager = new UserManager();
    }

}
