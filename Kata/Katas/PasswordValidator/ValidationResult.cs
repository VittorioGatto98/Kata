using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Katas.PasswordValidator
{
    public class ValidationResult
    {
        public string errorMessages { get; private set; }
        public bool statusResult = true;
        public ResourceManager rm { get; set; }

        public ValidationResult()
        {
          rm = new ResourceManager("Errors", Assembly.GetExecutingAssembly());
        }

        public void AddToValidationResult(string msgResult)
        {
            statusResult = false;
            errorMessages += $"\n{msgResult}";
        }
    }
}
