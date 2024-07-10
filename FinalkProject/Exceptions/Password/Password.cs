using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    internal class Password
    {
        public string Pass { get; set; }
        public Password(string pass)
        {
            Pass = pass;
        }
        public void PassCheck(Label error1, Label error2, Label error3)
        {
            InvalidPasswordException ExceptionCatcher = null;
            if (Pass.Length < 8)
            {
                error1.Visible = true;
                ExceptionCatcher = new InvalidPasswordException();
            }
            else
            {
                error1.Visible = false;
            }
            if (!HasUpperCheck(Pass))
            {
                error2.Visible = true;
                ExceptionCatcher = new InvalidPasswordException();
            }
            else
            {
                error2.Visible = false;
            }
            if (!HasSpecialSymbolCheck(Pass))
            {
                error3.Visible = true;
                ExceptionCatcher = new InvalidPasswordException();
            }
            else
            {
                error3.Visible = false;
            }
            if (ExceptionCatcher != null)
            {
                throw new InvalidPasswordException();
            }
        }
        private bool HasUpperCheck(string password)
        {
            foreach (var letter in password)
            {
                if ((int)(letter) > 64 && (int)(letter) < 91)
                {
                    return true;
                }
            }
            return false;
        }
        private bool HasSpecialSymbolCheck(string password)
        {
            foreach (var letter in password)
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
