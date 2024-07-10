using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    public class InvalidUsernameException : Exception
    {
        public string ErrorMessage = "Incorrect username, try again!";
        public InvalidUsernameException()
        {
        }
    }
}
