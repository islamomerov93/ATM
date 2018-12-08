using System;

namespace CashDispenser
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] users = new User[]
            {
                new User("Islam","Omerov",new Card("3432567891098476","5676","345","06/20",1000.00m)),
                new User("Tural", "Mustafayev", new Card("1221345093023246", "5678", "123", "06/21", 800.00m)),
                new User("Murad", "Huseynov", new Card("556431332062778", "5432", "120", "06/23", 900.00m)),
                new User("Saleh", "Abdullabeyli", new Card("998686132512574", "9876", "456", "06/21", 600.00m)),
                new User("Zaur", "Pasha", new Card("4652931506489762", "5555", "789", "06/20", 1250.00m))
            };

            bool check = true;
            int index = 0;

            while (check)
            {
                try
                {
                    Console.WriteLine("Enter PIN:");
                    string pin = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(pin)) throw new Exception("PIN section is empty");
                    for (int i = 0; i < users.Length; i++)
                    {
                        if (pin == users[i].CreditCard.pin)
                        {
                            check = false;
                            index = i;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
            while (true)
            {
                try
                {
                    Console.Clear();
                    //Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\t\t\tWelcome {users[index].name} {users[index].surname}");
                    Console.ResetColor();
                    Console.WriteLine("\n\t\t\tChoice command:");
                    Console.WriteLine("|Show balance - 1 | Get cash - 2 | Show Log - 3| Money Transfer - 4|");
                    string choiceTmp = Console.ReadLine();
                    if (!int.TryParse(choiceTmp, out int choice)) throw new Exception("Wrong input");
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"Balance: {users[index].CreditCard.balance}");
                            break;
                        case 2:
                            {
                                Console.WriteLine("1 - 10 AZN");
                                Console.WriteLine("2 - 20 AZN");
                                Console.WriteLine("3 - 50 AZN");
                                Console.WriteLine("4 - 100 AZN");
                                Console.WriteLine("5 - Manually");
                                choiceTmp = Console.ReadLine();
                                if (!int.TryParse(choiceTmp, out int choiceM)) throw new Exception("Wrong input");
                                switch (choiceM)
                                {
                                    case 1:
                                        {
                                            if (10 > users[index].CreditCard.balance) throw new Exception("Not enough money");
                                            else
                                            {
                                                users[index].CreditCard.balance -= 10;
                                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine($"Sucessfull, current balance {users[index].CreditCard.balance}");
                                                Console.ResetColor();
                                                Array.Resize(ref users[index].Log, users[index].Log.Length + 1);
                                                string tmp = DateTime.Now.ToString("MM/dd/yyyy H:mm").ToString();
                                                tmp += " 10 AZN out";
                                                int tmpIndex = users[index].Log.Length - 1;
                                                users[index].Log[tmpIndex] = tmp;
                                                users[index].LogCheck = true;
                                            }
                                        }
                                        break;
                                    case 2:
                                        {
                                            if (20 > users[index].CreditCard.balance) throw new Exception("Not enough money");
                                            else
                                            {
                                                users[index].CreditCard.balance -= 20;
                                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine($"Sucessfull, current balance {users[index].CreditCard.balance}");
                                                Console.ResetColor();
                                                Array.Resize(ref users[index].Log, users[index].Log.Length + 1);
                                                string tmp = DateTime.Now.ToString("MM/dd/yyyy H:mm").ToString();
                                                tmp += " 20 AZN out";
                                                int tmpIndex = users[index].Log.Length - 1;
                                                users[index].Log[tmpIndex] = tmp;
                                                users[index].LogCheck = true;
                                            }
                                        }
                                        break;
                                    case 3:
                                        {
                                            if (50 > users[index].CreditCard.balance) throw new Exception("Not enough money");
                                            else
                                            {
                                                users[index].CreditCard.balance -= 50;
                                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine($"Sucessfull, current balance {users[index].CreditCard.balance}");
                                                Console.ResetColor();
                                                Array.Resize(ref users[index].Log, users[index].Log.Length + 1);
                                                string tmp = DateTime.Now.ToString("MM/dd/yyyy H:mm").ToString();
                                                tmp += " 50 AZN out";
                                                int tmpIndex = users[index].Log.Length - 1;
                                                users[index].Log[tmpIndex] = tmp;
                                                users[index].LogCheck = true;
                                            }
                                        }
                                        break;
                                    case 4:
                                        {
                                            if (100 > users[index].CreditCard.balance) throw new Exception("Not enough money");
                                            else
                                            {
                                                users[index].CreditCard.balance -= 100;
                                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine($"Sucessfull, current balance {users[index].CreditCard.balance}");
                                                Console.ResetColor();
                                                Array.Resize(ref users[index].Log, users[index].Log.Length + 1);
                                                string tmp = DateTime.Now.ToString("MM/dd/yyyy H:mm").ToString();
                                                tmp += " 100 AZN out";
                                                int tmpIndex = users[index].Log.Length - 1;
                                                users[index].Log[tmpIndex] = tmp;
                                                users[index].LogCheck = true;
                                            }
                                        }
                                        break;
                                    case 5:
                                        {
                                            Console.WriteLine("Enter amount of money");
                                            string input = Console.ReadLine();
                                            if (!decimal.TryParse(input, out decimal OutMoney)) throw new Exception("Wrong value");
                                            if (OutMoney > users[index].CreditCard.balance) throw new Exception("Not enough money");
                                            else
                                            {
                                                users[index].CreditCard.balance -= OutMoney;
                                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine($"Sucessfull, current balance {users[index].CreditCard.balance}");
                                                Console.ResetColor();
                                                Array.Resize(ref users[index].Log, users[index].Log.Length + 1);
                                                string tmp = DateTime.Now.ToString("MM/dd/yyyy H:mm").ToString();
                                                tmp += $" {OutMoney} AZN out";
                                                int tmpIndex = users[index].Log.Length - 1;
                                                users[index].Log[tmpIndex] = tmp;
                                                users[index].LogCheck = true;
                                            }
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("There is no command like this");
                                        break;
                                }
                            }
                            break;
                        case 3:
                            {
                                if (users[index].LogCheck)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    for (int i = 0; i < users[index].Log.Length; i++)
                                    {
                                        Console.WriteLine($"Last changed: {users[index].Log[i]}");
                                    }
                                    Console.ResetColor();
                                }
                                else Console.WriteLine("there is no any changes");
                            }
                            break;
                        case 4:
                            {
                                bool chk = true;
                                int transferIndex = 0;
                                while (chk)
                                {
                                    bool same = false;
                                    Console.WriteLine("Enter PIN you want to money transfer:");
                                    string pin = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(pin)) throw new Exception("PIN section is empty");
                                    for (int i = 0; i < users.Length; i++)
                                    {
                                        if (pin == users[i].CreditCard.pin)
                                        {
                                            if (users[i].CreditCard.pin == users[index].CreditCard.pin)
                                            {
                                                Console.WriteLine("This is your PIN!");
                                                same = true;
                                                continue;
                                            }
                                            chk = false;
                                            transferIndex = i;
                                            break;
                                        }
                                    }
                                    if (!same && chk) Console.WriteLine("Account not found, please enter again");
                                }
                                Console.WriteLine("Enter amount of money to transfer");
                                string input = Console.ReadLine();
                                if (!decimal.TryParse(input, out decimal OutMoney)) throw new Exception("Wrong value");
                                if (OutMoney > users[index].CreditCard.balance) throw new Exception("Not enough money");
                                else
                                {
                                    users[index].CreditCard.balance -= OutMoney;
                                    users[transferIndex].CreditCard.balance += OutMoney;
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Sucessfull, current balance {users[index].CreditCard.balance}");
                                    Console.WriteLine($"{OutMoney} AZN added {users[transferIndex].name} {users[transferIndex].surname}'s balance");
                                    Console.ResetColor();
                                    Array.Resize(ref users[index].Log, users[index].Log.Length + 1);
                                    string tmp = DateTime.Now.ToString("MM/dd/yyyy H:mm").ToString();
                                    tmp += $" {OutMoney} AZN Transfered";
                                    int tmpIndex = users[index].Log.Length - 1;
                                    users[index].Log[tmpIndex] = tmp;
                                    users[index].LogCheck = true;
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("There is no command like this");
                            break;
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }

            }

        }
    }
    class Card
    {
        string PAN, PIN, CVC, Date;
        decimal Balance;
        public Card(string pan, string pin, string cvc, string date, decimal balance)
        {
            PAN = pan;
            PIN = pin;
            CVC = cvc;
            Date = date;
            Balance = balance;
        }
        public string pan { get { return PAN; } }
        public string pin { get { return PIN; } }
        public string cvc { get { return CVC; } }
        public string eDate { get { return Date; } }
        public decimal balance { get { return Balance; } set { Balance = value; } }
    }
    class User
    {
        string Name, Surname;
        public Card CreditCard;
        public string[] Log = new string[0];
        public bool LogCheck = false;
        public User(string name, string surname, Card tmp)
        {
            Name = name;
            Surname = surname;
            CreditCard = tmp;
        }
        public string name { get { return Name; } }
        public string surname { get { return Surname; } }
    }
}
