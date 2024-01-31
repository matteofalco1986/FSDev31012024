using System;

namespace GestioneConto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isDone = false;
            while (!isDone)
            {
                Console.WriteLine("***************************");
                Console.Write("\nBenvenuto in conto Arancino. Vuoi aprire un conto?\nDigita Y o N: ");
                string userResponse = Console.ReadLine().ToLower();

                // Se l'utente non vuole aprire un conto
                if (userResponse == "n")
                {
                    Console.WriteLine("Grazie per aver utilizzato i nostri servizi");
                    isDone = true;
                    break;
                }

                // Se l'utente vuole aprire un conto
                Console.Write("\nNome: ");
                string accountName = Console.ReadLine();
                Console.WriteLine($"\nBenvenuto {accountName}.\nCongratulazioni per aver aperto il tuo nuovo conto." +
                    $"\nOra manca un piccolo passo. Devi depositare una somma iniziale" +
                    $"\nQuanto desideri depositare? ");

                // Verifica se la somma iniziale è sufficiente
                bool isEnough = false;
                int initialAmount = 0;
                while (!isEnough)
                {
                    initialAmount = int.Parse(Console.ReadLine());
                    if (initialAmount < 1000)
                    {
                        Console.WriteLine("\nMi dispiace, devi depositare almeno 1000€. Riprova con una somma maggiore");
                        Console.WriteLine("Quanto desideri depositare?");
                    }
                    else
                    {
                        isEnough = true;
                    }
                }

                Account myAccount = new Account(accountName, initialAmount);
                Console.WriteLine("\nIl tuo conto è ora aperto");
                Console.WriteLine("Cosa desideri fare?");

                isDone = false;
                while (!isDone)
                {
                    Console.WriteLine("\nScegli un'opzione");
                    Console.WriteLine("S - Saldo");
                    Console.WriteLine("P - Preleva");
                    Console.WriteLine("D - Deposita");
                    Console.WriteLine("E - Esci");

                    string userAnswer = Console.ReadLine().ToLower();
                    switch (userAnswer)
                    {
                        case "e":
                            Console.WriteLine("\nGrazie per aver usato conto arancino. A presto!");
                            isDone = true;
                            break;
                        case "s":
                            Console.WriteLine($"\nIl tuo saldo disponibile è {myAccount.Amount} €");
                            Console.WriteLine("Quale altra operazione desideri effettuare?");
                            break;
                        case "p":
                            Console.WriteLine("\nQuanto desideri prelevare?");
                            int amountToWithdraw = int.Parse(Console.ReadLine());
                            if (amountToWithdraw > myAccount.Amount)
                            {
                                Console.WriteLine("Mi dispiace, Il tuo saldo disponibile non è sufficiente.");
                            }
                            else if (amountToWithdraw < 0)
                            {
                                Console.WriteLine("Mi dispiace, non puoi prelevare una cifra negativa.");
                            }
                            else
                            {
                                myAccount.Withdraw(amountToWithdraw);
                                Console.WriteLine($"Hai prelevato {amountToWithdraw}€.");
                                Console.WriteLine($"Il tuo saldo disponibile è {myAccount.Amount}€");
                            }
                            break;
                        case "d":
                            Console.WriteLine("\nQuanto desideri depositare?");
                            int amountToDeposit = int.Parse(Console.ReadLine());
                            if (amountToDeposit < 10)
                            {
                                Console.WriteLine("Mi dispiace, devi depositare almeno 10 €");
                            }
                            else
                            {
                                myAccount.Deposit(amountToDeposit);
                                Console.WriteLine($"\nIl deposito di {amountToDeposit}€ è stato effettuato sul tuo conto.");
                                Console.WriteLine($"Il tuo saldo disponibile è {myAccount.Amount}€");
                            }
                            Console.WriteLine("\nQuale altra operazione desideri effettuare?");
                            break;
                        default:
                            Console.WriteLine("\nMi dispiace, devi selezionare un'opzione valida. Riprova.\n");
                            break;
                    }
                }

            }


        }

    }
    public class Account
    {
        // Fields
        string _name;
        int _amount;

        // Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        // Methods
        public void Withdraw(int amount)
        {
            Amount -= amount;
        }

        public void Deposit(int amount)
        {
            Amount += amount;
        }

        // Constructor
        public Account(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}