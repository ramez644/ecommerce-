using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Oseas.ViewModel
{
    public class RegisterViewModel
    {
        
        [MaxLength(50)]

        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        public string Address { get; set; }



    }
}
