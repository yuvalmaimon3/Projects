using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.FirstInstruction();

            Bank b = new Bank();
            b.Start();
            
        }
        private void FirstInstruction()
        {
            Console.WriteLine("This application simolate ATM interface");
            Console.WriteLine("First you need to insert only name from the list");
            Console.WriteLine("Avi, Pincode = 1818");
            Console.WriteLine("Dani, Pincode = 2800");
            Console.WriteLine("Maik, Pincode = 1936");
            Console.WriteLine("Yossi, Pincode = 1754");
            Console.WriteLine("David, Pincode = 1065");
            Console.WriteLine();
            
        }
    }
    class Bank
    {

        private int index = 0;
        public Bank()
        {


        }


        //initializes all the users
        private List<Person> InitializesList(List<Person> p)
        {
            p.Add(new Person { PinCode = 1818, Name = "Avi", Money = 1500.00, Transaction = 3 });
            p.Add(new Person { PinCode = 2800, Name = "Dani", Money = 5000.00, Transaction = 6 });
            p.Add(new Person { PinCode = 1936, Name = "Maik", Money = 15450.00, Transaction = 10 });
            p.Add(new Person { PinCode = 1754, Name = "Yossi", Money = 6500.00, Transaction = 7 });
            p.Add(new Person { PinCode = 1065, Name = "David", Money = 11200.00, Transaction = 11 });
            return p;
        }
        // the base method who call all the method
        public void Start()
        {
            
            bool run = true;
            int act;
            List<Person> PersonList = new List<Person>();
            PersonList = InitializesList(PersonList);
            var User = new Person();    
            User = VerifyUser(PersonList);
            while(run)
            {
                Console.WriteLine();
                act = Menu();
                switch(act)
                {
                    case 1: Withdraw(User);
                        break;
                    case 2: Deposit(User);
                        break;
                    case 3: Available(User);
                        break;
                    case 4: ChangePinCode(User);
                        break;
                    case 5: History(User);
                        break;
                    case 6 : run = Exit();
                        break;

                        
                }
            }
            

        }
        // Display the ATM options
        static int Menu()
        {
            
            int num;
            Console.WriteLine("Press the number of action you want to do");
            Console.WriteLine("1)Withdraw cash                2)Deposit cash");
            Console.WriteLine();
            Console.WriteLine("3)Show available money         4)Change pin code");
            Console.WriteLine();
            Console.WriteLine("5)Show last 5 action           6)Exit");
            num = int.Parse(Console.ReadLine());
            Console.Clear();
            return num;
        }
        // verify the user and pincode the customer insert
        private Person VerifyUser(List<Person> MyList)
        {
            Bank b = new Bank();
            index = 0;
            Person Check;//Get info from the client
            Check = GetUserAndPincode();//Get info from the client

            IEnumerator<Person> itor = MyList.GetEnumerator();
            while (itor.MoveNext())
            {

                if (Check.Name == itor.Current.Name)
                {
                    if (Check.PinCode == itor.Current.PinCode)
                    {
                        Console.WriteLine("the user verify");
                        break;
                    }

                }
                index++;
                if (index >= MyList.Count)
                {
                    Console.WriteLine();
                    Console.WriteLine("Bad login, try agin,user or password is not compatible");
                    Console.WriteLine();
                    Console.WriteLine();
                    index = 0;
                    b.Start();
                }
               
            }
            return itor.Current;
        }
        //input user and password
        static Person GetUserAndPincode()
        {
            Console.WriteLine("Wrtie your name");
            string name = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("Write the linked Pincode from the list");
            Console.WriteLine();
            Console.WriteLine("Wrtie your pincode");
            int pincode = PinCode();
            var GetPerson = new Person() { PinCode = pincode, Name = name };

            return GetPerson;



        }


        static int PinCode()
        {
            int pinCode=0;
            bool tryAgin = true;
            while(tryAgin)
            {
                try
                {
                    tryAgin = false;
                    pinCode = int.Parse(Console.ReadLine());
                    if (pinCode <= 999 || pinCode > 9999)
                    {
                        Console.WriteLine("The pin code invalid");
                        Console.WriteLine("Please insert only number in domain 4 character");
                        tryAgin = true;
                    }
                }
                catch
                {
                    Console.WriteLine("The pin code invalid");
                    Console.WriteLine("Please insert only number in domain 4 character");
                    tryAgin = true;
                }
            }
            
            return pinCode;
        }
        //change pin code
        private Person ChangePinCode(Person user)
        {
            
            bool pass;
            int pincode;
            Console.WriteLine("Write new Pincode.");

            do
            {
                
                pass = false;
                try
                {
                    Console.WriteLine("Enetr new Pincode");
                    pincode = int.Parse(Console.ReadLine());
                    Console.WriteLine("The Pincode has been change");
                }
                catch(Exception e)
                {
                    
                    Console.WriteLine("the PinCode invalid");
                    Console.WriteLine("please insert only number in domain 4 character");
                    pincode = user.PinCode;//Recursion
                    pass = true;
                }
                user.HistoryPerson.Push("Pincode Changed");

            } while (pincode <= 999 || pincode > 9999 || pass);// must to be false to continue

            user.PinCode = pincode;
            
            return user;
        }
        //how much money exist
        static void Available(Person p)
        {
            
            Console.WriteLine("you have :" + p.Money + " "+"in your account bank");
            
        }
  
        //withdraw cash
        private Person Withdraw(Person p)
        {
            Console.Clear();
            var user = p;
            Console.WriteLine("how much money did you to withdraw?");
            Console.WriteLine("1)50           2)100");
            Console.WriteLine();
            Console.WriteLine("3)150          4)200");
            Console.WriteLine();
            Console.WriteLine("5)300          6)400");
            Console.WriteLine("0) no action");
            Console.WriteLine("press the appropriate number");
            int amount = int.Parse(Console.ReadLine());
            switch (amount)
            {
                case 0: break;

                case 1: user.Money -= 50;
                    Console.Clear();
                    Console.WriteLine("The transaction completed successfully.You withdraw 50 dollar");
                    user.HistoryPerson.Push("Withdraw 50 Dollar.");
                    break;
                case 2: user.Money -= 100;
                    Console.Clear();
                    Console.WriteLine("The action was executed.You withdraw 100 dollar");
                    user.HistoryPerson.Push("Withdraw 100 Dollar.");
                    break;
                case 3: user.Money -= 150;
                    Console.Clear();
                    Console.WriteLine("The transaction completed successfully.You withdraw 150 dollar");
                    user.HistoryPerson.Push("Withdraw 150 Dollar.");
                    break;
                case 4: user.Money -= 200;
                    Console.Clear();
                    Console.WriteLine("The transaction completed successfully.You withdraw 200 dollar");
                    user.HistoryPerson.Push("Withdraw 200 Dollar.");
                    break;
                case 5: user.Money -= 300;
                    Console.Clear();
                    Console.WriteLine("The transaction completed successfully.You withdraw 300 dollar");
                    user.HistoryPerson.Push("Withdraw 300 Dollar.");
                    break;
                case 6: user.Money -= 400;
                    Console.Clear();
                    Console.WriteLine("The transaction completed successfully. You withdraw 400 dollar");
                    user.HistoryPerson.Push("Withdraw 400 Dollar.");
                    break;
            }
            
            return user;
        }
        //deposit cash
        private static Person Deposit(Person user)
        {
         
            double money;
            Console.WriteLine("Write the number of money you want to Deposit");
            try
            {
                money = int.Parse(Console.ReadLine());
                user.Money += money;
                user.HistoryPerson.Push("Deposit " + money + " Dollar");
                Console.Clear();
                Console.WriteLine("The transaction completed successfully");
            }
            catch
            {
                Console.WriteLine("Some thing incorrect please incert only numbers");
                Deposit(user);
            }
            
            return user;


        }
        private static void History(Person user)
        {
           
            Console.WriteLine("Your last 5 action");
            Console.WriteLine("-------------------");
            foreach (string corrent in user.HistoryPerson)
            {
                if(corrent !="")
                Console.WriteLine(corrent);
            }
            
     
        }
        //Exit
        private bool Exit()
        {
            return false;
        }
        static void Space()
        {
            for (int i = 0; i <10; i++)
            {
                Console.WriteLine();
            }
        }
    }
        class Person
        {
            public Stack<string> HistoryPerson = new Stack<string>(5);
            private int transactions;
            private double money;
            private int pincode;
            private string name;

            public int PinCode
            {
                get { return pincode; }
                set { pincode = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public double Money
            {
                get { return money; }
                set { money = value; }
            }
            public int Transaction
            {
                get { return transactions; }
                set { transactions = value; }
            }
        }

    }



