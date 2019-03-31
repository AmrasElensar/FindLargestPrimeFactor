using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindLargestPrimeFactor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to find it's largest prime factor:");
            long input = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine(FindLargestPrimeFactor(input));

            Console.ReadKey();
        }

        public static long FindLargestPrimeFactor(long num) // finding the largest prime factor
        {
            long largestPrime = FindPrimeFactors(num).Max();

            return largestPrime;
        }

        public static List<long> FindPrimeFactors(long num) // finding all the prime factors
        {
            List<long> primeFactors = new List<long>();
            List<long> primeNumbers = FindPrimes(num);

            bool CheckPrimeFactor(long x, long y) // function to check if number is prime factor
            {
                if (x % y == 0)
                {
                    return true;
                }
                return false;
            }

            foreach (long n in primeNumbers)
            {
                while (CheckPrimeFactor(num, n))
                {
                    primeFactors.Add(n);
                    num = num / n;
                }
            }

            return primeFactors;
        }

        public static List<long> FindPrimes(long num) // Finding all prime numbers, based on the Sieve of Eratosthenes : https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
        {
            List<long> primes = new List<long>();
            List<long> noPrimes = new List<long>();

            for (int i = 2; i < Math.Sqrt(num); i++)
            {
                for (int j = (int)Math.Pow(i, 2); j < num; j = j + i)
                {
                    noPrimes.Add(j);
                }
            }

            for (int i = 2; i < num; i++)
            {
                if (!noPrimes.Contains(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }
    }
}
