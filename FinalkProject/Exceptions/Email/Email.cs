using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    internal class Email
    {
        private bool correctDomain = true;
        public string Mail { get; set; }
        List<string> EmailDomains = new List<string> {"gmail.com", "abv.bg", "itpg-varna.bg", "yahoo.com", "hotmail.com" };
        public Email(string mail)
        {
            Mail = mail;
        }
        public void PassCheck(Label error1, Label error2, Label error3)
        {
            InvalidEmailException ExceptionCatcher = null;
            if (Mail.Length < 6)
            {
                error1.Visible = true;
                ExceptionCatcher = new InvalidEmailException();
            }
            else
            {
                error1.Visible = false;
            }


            if (Mail.Length > 30)
            {
                error2.Visible = true;
                ExceptionCatcher = new InvalidEmailException();
            }
            else
            {
                error2.Visible = false;
            }

            if (!CorrectDomain(Mail))
            {
                error3.Visible = true;
                ExceptionCatcher = new InvalidEmailException();
            }
            else
            {
                error3.Visible = false;
            }


            if (ExceptionCatcher != null)
            {
                throw new InvalidEmailException();
            }
        }
        
        private bool CorrectDomain(string email)
        {
            
            string[] asd = email.Split("@");
            foreach (string item in EmailDomains) 
            {
                if(asd.Length < 2)
                {
                    return false;
                }
                if (item == asd[1])
                {
                    correctDomain = true;
                }
            }
            if (correctDomain)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
