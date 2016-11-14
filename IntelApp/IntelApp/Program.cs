using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace IntelApp
{
    class Program
    {


        static List<Users> UserList = new List<Users>(5);

        static void Main(string[] args)
        {
            AddStartUsers();
            ShowMenu();
        }

        static void ShowMenu()
        {
            String menu = "";
            menu += "------ Database ------\n" +
                    "1. Show users\n" +
                    "2. Add user\n" +
                    "3. Delete user\n" +
                    "Enter : ";

            Console.Write(menu);


            GetUserAnswerAndChooseTask();

        }


        static void GetUserAnswerAndChooseTask()
        {
            string answer = Console.ReadLine();
            try
            {
                WhichTask(int.Parse(answer));
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Something goes wrong, please try again.");
                Console.ReadLine();
                ShowMenu();

            }


        }

        static void WhichTask(int option)
        {
            switch (option)
            {
                case 1:
                    ShowUsers();
                    break;

                case 2:
                    AddUser();
                    break;


                case 3:
                    DeleteUser();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Choose correct option from 1-3.");
                    Console.ReadLine();
                    ShowMenu();
                    break;

            }

        }

        static void ShowUsers()
        {
            Console.Clear();

            SortAndShowUserList();

            ShowMenu();


        }

        static void AddUser()
        {
            Users user1 = new Users();
            Console.Clear();

            Console.Write("--- Add User ---\n" +
                          "Enter name : ");

            string answerName = "", answerMail = "";

            answerName = Console.ReadLine();

            Console.WriteLine("\nEnter mail :");

            answerMail = Console.ReadLine();


            if (UserList.Count >= UserList.Capacity)
            {
                Console.Clear();
                Console.Write("You can't add more users. The user list is full.\n");
            }
            else
            {
                user1.Name = answerName;
                user1.MailAdress = answerMail;
                if (CheckUniqueMail(answerMail) && user1.Name != "" && user1.MailAdress != "")
                {
                    UserList.Add(user1);
                }
                else
                {
                    Console.WriteLine("Not unique email address or wrong data entered");
                }

            }

            ShowMenu();
        }

        static void DeleteUser()
        {
            int deleteAnswer;
            Console.Clear();

            SortAndShowUserList();

            Console.Write("\nWrite which user you would like to delete : ");

            bool successfullyParsed = int.TryParse(Console.ReadLine(), out deleteAnswer);
            if (successfullyParsed)
            {
                if (deleteAnswer > 5)
                {
                    Console.WriteLine("Max number of users is 5 can't delete : " + deleteAnswer.ToString());
                }
                else
                {
                    UserList.RemoveAt(--deleteAnswer);
                }
                
            }

            ShowMenu();
        }

        static void SortAndShowUserList()
        {
            UserList.Sort((x, y) => string.Compare(x.Name, y.Name));

            for (int i = 0; i < UserList.Count; i++)
            {
                UserList[i].ShowUser(i);
            }
        }

        static void AddStartUsers()
        {
            Users one = new Users("Jan","abc@wp.pl") , two = new Users("Adam","aa@wp.pl") ,three = new Users("Zbigniew","ccc@wp.pl") , four = new Users("Bartek", "xxc@wp.pl") ;
            UserList.Add(one);
            UserList.Add(two);
            UserList.Add(three);
            UserList.Add(four);

        }

        static bool CheckUniqueMail(string mail)
        {
            for (int i = 0; i < UserList.Count; i++)
            {
                if (UserList[i].MailAdress == mail)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
