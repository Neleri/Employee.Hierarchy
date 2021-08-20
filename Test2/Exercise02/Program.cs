using Exercise01;
using System;
using System.Numerics;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Enter a Number");

                string number = Console.ReadLine();

                number = Convert.ToDouble(number).ToString();

                long enteredValue = long.Parse(number);

                Console.WriteLine(enteredValue.ConvertWholeNumber());
                
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("Hello World!");
        }
    }
}
