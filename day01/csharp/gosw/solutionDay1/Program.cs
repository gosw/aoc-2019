using System;
using System.IO;

namespace solutionDay1
{
    class Program
    {
        static void Main(string[] args)
        {
            var fuelSum = 0;
            try
            {
                using (var input = new StreamReader("input.txt"))
                {
                    var line = "";
                    while ((line = input.ReadLine()) != null)
                    {
                        fuelSum += fuelForModule(line);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Fuel needed: " + fuelSum);
            Console.ReadLine();
        }

        private static int fuelForModule(string moduleMass)
        {
            var fuelAmount = 0;
            if (Int32.TryParse(moduleMass, out fuelAmount))
            {
                fuelAmount = (fuelAmount / 3) - 2;
                if (fuelAmount >= 0)
                {
                    fuelAmount += fuelForFuel(fuelAmount);
                }
            }

            return fuelAmount;
        }

        private static int fuelForFuel(int fuelAmount)
        {
            var additionalFuel = 0;
            var fuelWeight = fuelAmount;

            do
            {
                var currentFuelWeight = (fuelWeight / 3) - 2;
                fuelWeight = (currentFuelWeight < 0) ? 0 : currentFuelWeight;
                additionalFuel += fuelWeight;
            } while (fuelWeight > 0);

            return additionalFuel;
        }
    }
}
