using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace IntelApp
{
    public class Users
    {
        private string _name = "";
        private string _mailAdress = "";

        private static readonly char[] SpecialChars = "!@#$%^&*()ąćśźżół-+=1234567890".ToCharArray();


        public Users()
        { }

        public Users(string nam, string mail)
        {
            Name = nam;
            MailAdress = mail;
        }

        public string MailAdress
        {
            get { return _mailAdress; }
            set
            {
               if (CheckEmail(value))
                   _mailAdress = value;
               else
               {
                   Console.WriteLine("Incorrrect email address");
               }
               
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
               if (CheckName(value))
               _name = value;
               else
               {
                   Console.WriteLine("Incorrrect name");
               }
               
            }
        }

        bool CheckEmail(string mail)
        {

            if (new EmailAddressAttribute().IsValid(mail))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        bool CheckName(string name)
        {
            
            int indexOf = name.IndexOfAny(SpecialChars);
            if (indexOf == -1 && name.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }

           
        }



        public void ShowUser(int num)
        {
            num++;
            Console.WriteLine("User " + num.ToString() + ": " + Name + " email adress : " + MailAdress);
        }
    }
}

