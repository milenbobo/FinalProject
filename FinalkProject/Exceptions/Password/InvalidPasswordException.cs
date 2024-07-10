using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    public class InvalidPasswordException : Exception
    {
        public string ErrorMessage = "Incorrect password, try again!";
        public InvalidPasswordException()
        {
        }
    }
}
