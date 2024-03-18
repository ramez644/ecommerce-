using System.ComponentModel.DataAnnotations;

namespace Oseas.Validation
{
    public class FileExtensionAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);


                string[] extensions = { "jpg,png" };
                bool result = extensions.Any(x => extension.EndsWith(x));
                if (!result)
                {

                    return new ValidationResult("the alowed extension is jpg or png");

                }
            }



            return ValidationResult.Success;

        }
    }
}

    

