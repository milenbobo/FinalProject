    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    internal class Username
    {
        public string Name { get; set; }
        public Username(string name)
        {
            Name = name;
        }
        public void NameCheck( Label error1, Label error2, Label error3, Label usernameerror4, string username, List<string> Users)
        {
            InvalidUsernameException ExceptionCatcher = null;
            if (Name.Length < 4)
            {
                error1.Visible = true;
                ExceptionCatcher = new InvalidUsernameException();
            }
            else
            {
                error1.Visible = false;

            }
            if (Name.Length > 20)
            {
                error2.Visible = true;
                ExceptionCatcher = new InvalidUsernameException();
            }
            else
            {
                error2.Visible = false;
            }
            if (HasSpecialSymbolCheck(Name))
            {
                ExceptionCatcher = new InvalidUsernameException();
                error3.Visible = true;
            }
            else
            {
                error3.Visible = false;
            }
            foreach (var item in Users)
            {
                string[] asd = item.Split(" ");
                if (Name + ";" == asd[2])
                {
                    ExceptionCatcher = new InvalidUsernameException();
                    usernameerror4.Visible = true;
                    break;
                }
            }
            if (ExceptionCatcher != null)
            {
                throw new InvalidUsernameException();
            }


        }
        
        private bool HasSpecialSymbolCheck(string username)
        {
            foreach (var letter in username)
            {
                if (((int)(letter) > 32 && (int)(letter) < 48) || ((int)(letter) > 57 && (int)(letter) < 65) || ((int)(letter) > 90 && (int)(letter) < 97) || ((int)(letter) > 122 && (int)(letter) < 127))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
