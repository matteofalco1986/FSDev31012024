using System;

namespace Esercizio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creiamo il nostro array di numeri");
            Console.Write("\nQuanti numeri vuoi nell' array? ");
            int arraySize = int.Parse(Console.ReadLine());
            double[] numbers = new double[arraySize];

            Console.WriteLine($"\nOttimo, il tuo array è di {numbers.Length} elementi.");
            Console.WriteLine("Ora popoliamo l'array con dei numeri. L'algoritmo ci restituirà la somma e la media matematica dei numeri inseriti");

            for (int i = 0; i < numbers.Length; ++i)
            {
                Console.Write($"Inserisci un numero: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Il tuo array è: [");

                foreach (var number in numbers)
            {
                Console.Write($"{number},");
            }
            Console.Write("]\n");

            double sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"\nLa somma dei numeri nell'array è: {sum}");
            Console.WriteLine($"\nLa media dei numeri nell'array è {sum / numbers.Length}");


        }
    }
}