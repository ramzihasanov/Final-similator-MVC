
using System.ComponentModel.DataAnnotations;

namespace FinalExc.Areas.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(maximumLength:50)]
        public string Username { get; set; }
 
        [StringLength(maximumLength:15)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
