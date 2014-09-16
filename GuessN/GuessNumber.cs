using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    class Class1
    {
        static void comStep(int minVal, int maxVal, int avVal)
        {
            string answer;
            avVal = (minVal + maxVal) / 2;
            Console.WriteLine("Your number is " + avVal + "?");
            answer = Console.ReadLine();
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
            int guess = 0;
            guess = int.Parse(Console.ReadLine());
            while (guess != randomNumber)
            {
                if (guess > randomNumber)
                {
                    Console.WriteLine("Your guess is greater, try once more");
                    guess = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Your guess is less, try once more");
                    guess = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("You are correct!");
        }
        static void Main(string[] args)
        {
            bool gameType;
            Console.WriteLine("Hello! Welcome to 'Guess number' program. Do you want to guess number yourself? (true/false)");
            gameType = bool.Parse(Console.ReadLine());
            int maxVal = 0;
            Console.WriteLine("Please enter the desired range");
            maxVal = int.Parse(Console.ReadLine());

            if (gameType == false)
            {
                int minVal = 0;
                int avVal = 0;
                Console.WriteLine("'+' if number is greater than guess, '-' if less, and the other input will be considirer as computer being correct");
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
