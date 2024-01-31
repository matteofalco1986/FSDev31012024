using System;

namespace EserciziArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ora costruiremo un array");

            bool isValid = false;
            int numberOfElements = 1;

            // Verifica che l'utente abbia inserito un numero positivo
            while (!isValid)
            {
                Console.Write("\nQuanti elementi vuoi nel tuo array? ");
                numberOfElements = int.Parse(Console.ReadLine());
                if (numberOfElements < 1)
                {
                    Console.WriteLine("\nDevi inserire un numero > 0. Prova ancora.");
                }
                else
                {
                    isValid = true;
                }
            }

            string[] namesArray = new string[numberOfElements];
            Console.WriteLine($"\nL'array creato contiene {namesArray.Length} elementi");
            Console.WriteLine("Ora inseriamo i nomi che conterrà l'array");

            for (int i=0; i < namesArray.Length; ++i)
            {
                Console.Write($"Nome {i + 1}: ");
                namesArray[i] = Console.ReadLine();
            }

            Console.WriteLine($"\nOttimo, il tuo array ora contiene {namesArray.Length} nomi.");
            Console.WriteLine("Ora digita un nome che desideri trovare. Io ispezionerò l'array e vedrò se c'è.");
            Console.Write("\nNome da trovare: ");
            string nameToFind = Console.ReadLine();
            bool isInArray = false;
            int index = 0;

            while (!isInArray && index < namesArray.Length)
            {
                if (namesArray[index].ToLower() == nameToFind.ToLower())
                {
                    Console.WriteLine($"\nCorrispondenza trovata per {namesArray[index]} all' indice {index}");
                    isInArray = true;
                    return;
                }
                ++index;
            }
            Console.WriteLine($"\nNessuna corrispondenza trovata per {nameToFind}");

            // Console.WriteLine(Array.IndexOf(namesArray, nameToFind)); // Metodo alternativo. Fornisce meno possibiltà di controllo. Richiede che i dati siano processati in ingresso.
        }
    }
}