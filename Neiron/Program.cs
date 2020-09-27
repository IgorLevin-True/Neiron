using System;

namespace Neiron
{
    class Program
    {
        private class Neiron
        {
            private decimal weight = 0.5m;
            public decimal LastError { get; private set; }

            public decimal Smoothing { get; set; } = 0.00001m;

            public decimal ProcessInputData(decimal input)
            {
                return input * weight;
            }

            public void Train(decimal input, decimal expectedResult)
            {
                var actualResult = input * weight;
                LastError = expectedResult - actualResult;
                var correction = (LastError / actualResult)*Smoothing;
                weight += correction;
            }


        }
        static void Main(string[] args)
        {
            decimal km = 100;
            decimal miles = 62.1371m;

            Neiron neiron = new Neiron();
            int i = 0;
            do
            {
                i++;

                neiron.Train(km, miles);
                Console.WriteLine($"Itreration: {i}\t Error: \t{neiron.LastError}");

            } while (neiron.LastError>neiron.Smoothing||neiron.LastError<-neiron.Smoothing);

            Console.WriteLine($"Learning is end");
            Console.WriteLine($"{neiron.ProcessInputData(100)}km in {100}miles");
            
        }
    }
}
