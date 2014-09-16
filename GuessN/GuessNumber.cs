using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GuessNumber
{
    class Class1
    {

        public static int Input(string input)
        {
            int number = 0;
            int.TryParse(input, out number);
            while (number == 0)
            {
                Console.WriteLine("You've entered invalid data, please enter valid one");
                int.TryParse(Console.ReadLine(), out number);
            }
            return number;
        }


        static void comStep(int minVal, int maxVal, int avVal)
        {
            avVal = (minVal + maxVal) / 2;
            Console.WriteLine("Your number is " + avVal + "?");
            string answer = Console.ReadLine();
            if (answer == "+")
            {
                minVal = avVal;
                comStep(minVal, maxVal, avVal);
            }
            else if (answer == "-")
            {
                maxVal = avVal;
                comStep(minVal, maxVal, avVal);
            }
            else
            {
                Console.WriteLine("Haha! I knew it!");
            }

        }
        
        
        static void humStep(int randomNumber)
        {
            int guess = Input(Console.ReadLine());
            while (guess != randomNumber)
            {
                if (guess > randomNumber)
                {
                    Console.WriteLine("Your guess is greater, try once more");
                    guess = Input(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Your guess is less, try once more");
                    guess = Input(Console.ReadLine());
                }
            }
            Console.WriteLine("You are correct!");
        }
        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to 'Guess number' program. Enter any number if you want to guess yourself or type anything else if you want computer to guess");
            int maxVal = 0;
            bool gameType = int.TryParse(Console.ReadLine(), out maxVal);
            Console.WriteLine("Please enter the desired range");
            maxVal = Input(Console.ReadLine());

            if (gameType == false)
            {
                int minVal = 0;
                int avVal = 0;
                Console.WriteLine("'+' if number is greater than guess, '-' if less, any other input will be considirer as computer being correct");
                comStep(minVal, maxVal, avVal);
            }
            else
            {
                Random random = new Random();
                maxVal = random.Next(0, maxVal);
                Console.WriteLine("Ok, I've got number, start guessing! :)");
                humStep(maxVal);
            }
        }
    }
}
