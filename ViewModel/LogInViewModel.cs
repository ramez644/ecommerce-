using System.ComponentModel.DataAnnotations;

namespace Oseas.ViewModel
{
    public class LogInViewModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Boolean RememberMe { get; set; }
    }
}
