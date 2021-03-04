using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventName
{
    class Program
    {
        static void Main(string[] args)
        {
            EnterName eName = new EnterName(); // new instace
            eName.BannedUser += WarningAlarm; // event
            eName.User();
            Console.Read();

        }
        static void WarningAlarm(object sender, BannedUserEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Banned user \"{0}\" found. Sending email to administration.", e.Name.ToUpper());
            Console.WriteLine("Email sent.");
            Console.WriteLine("Warning alarm started.");
            Console.ResetColor();
            Console.WriteLine("Press ctrl + c to stop the alarm:");
            for (;;)
            {
                Console.Beep();
                System.Threading.Thread.Sleep(100);
            }
        }
    }
    public class EnterName
    {
        public event EventHandler<BannedUserEventArgs> BannedUser;
        public void User()
        {
            Console.Write("Enter your name: ");
            string user = Console.ReadLine().ToLower();
            if ((user == "stefan" || user == "stefan trenh" || user == "nils" || user == "nils brufors" || user == "johan" || user == "johan rundström") && (BannedUser != null))
            {
                BannedUser(this, new BannedUserEventArgs(user));
            }
            if (user == "louis" || user == "louis headlam")
            {
                Console.WriteLine("Welcome {0}, you are the best!", user);
            }
            else
            {
                Console.WriteLine("Welcome {0}!", user);
            }
        }
    }
    public class BannedUserEventArgs : EventArgs
    {
        public BannedUserEventArgs(string s)
        {
            Name = s;
        }
        public string Name { get; set; }
    }
}
