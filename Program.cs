namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }

        
        static void StartGame()
        {
            Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");
            Random random = new Random();

            int number = random.Next(1, 21);
            int guess;
            int guesses = 0;
            string input = "";

            //Run game until amount of guesses been reached
            while (guesses < 5)
            {
                //Take input if not a number repeat
                do
                {
                    Console.WriteLine("Välj ett nummer:");
                    input = Console.ReadLine();
                }
                while (!Int32.TryParse(input, out guess));

                CheckGuess(guess, number);

                guesses++;
            }

            Console.WriteLine("Tyvärr, du lyckades inte gissa talet på fem försök!");
            Restart();
        }


        //Check guess against generated number and give clue if too high/low
        private static void CheckGuess(int guess, int number)
        {
            
            if (guess == number)
            {
                Console.WriteLine("Wohoo! Du klarade det!");
                Restart();
            }
            else if (guess > number)
            {
                Console.WriteLine("Tyvärr, du gissade för högt!");
            }
            else if (guess < number)
            {
                Console.WriteLine("Tyvärr, du gissade för lågt!");
                
            }
        }


        //Ask if player wants to play again if yes restart game
        private static void Restart()
        {
            
            
            Console.WriteLine("Vill du spela igen Y/N");

            var input = Console.ReadKey().Key;
            if (input == ConsoleKey.Y)
            {
                Console.Clear();
                StartGame();
            }
            else if(input == ConsoleKey.N)
            {
                Environment.Exit(0);
            }
            else
            {
                Restart();
            }
        }
    }
}