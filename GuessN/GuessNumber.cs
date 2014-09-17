using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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


        static void fromToText(int attempts)
        {
            Console.WriteLine("You are correct! Please enter your initials or name for the table of records");
            using (StreamWriter writer = new StreamWriter(@"c:\temp\GuessNumberByHuman.txt", true))
            {
                writer.Write(Console.ReadLine());
                writer.Write(" ");
                writer.WriteLine(attempts);
            }
            Console.WriteLine("Thank you! Here's the table of previous participants! Number next to name shows amount of attempts left, comparing with amount required for AI to find number from the same range");
            string[] table = File.ReadAllLines(@"c:\temp\GuessNumberByHuman.txt");
            var orderedTable = table.OrderByDescending(x => int.Parse(x.Split(' ')[1]));
            foreach (string line in orderedTable)
            {
                Console.WriteLine(line);
            }
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
        
        
        static void humStep(int randomNumber, int attempts)
        {
            int guess = Input(Console.ReadLine());
            attempts--;
            while (guess != randomNumber)
            {
                if (guess > randomNumber)
                {
                    Console.WriteLine("Your guess is greater, try once more");
                    guess = Input(Console.ReadLine());
                    attempts--;
                }
                else
                {
                    Console.WriteLine("Your guess is less, try once more");
                    guess = Input(Console.ReadLine());
                    attempts--;
                }
            }
            fromToText(attempts);
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
                int attempts = 0;
                while (Math.Pow(2,attempts) < maxVal)
                {
                    attempts++;
                }
                Random random = new Random();
                maxVal = random.Next(0, maxVal);
                Console.WriteLine("Ok, I've got number, start guessing! :)");
                humStep(maxVal, attempts);
            }
        }
    }
}
