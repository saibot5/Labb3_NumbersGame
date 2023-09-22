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
            //Difficulty[0] = min
            //Difficulty[1] = max
            //Difficulty[2] = max guesses
            int[] difficulty = new int[3];

            difficulty = ChooseDificulty();


            Console.WriteLine($"Välkommen! Jag tänker på ett nummer mellan {difficulty[0]} och {difficulty[1] - 1}. Kan du gissa vilket? Du får {difficulty[2]} försök.");
            Random random = new Random();

            int number = random.Next(difficulty[0], difficulty[1]);
            int guess;
            int guesses = 0;
            string input = "";

            //Run game until amount of guesses been reached
            while (guesses < difficulty[2])
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

        private static int[] ChooseDificulty()
        {

            string input;
            int result;
            int[] difficulty = new int[3];

            do
            {
                Console.WriteLine("Välj svårighetsgrad");
                Console.WriteLine("1. Lätt");
                Console.WriteLine("2. medium");
                Console.WriteLine("3. svårt");
                input = Console.ReadLine();
            } while (!Int32.TryParse(input, out result) || !(result >= 1 && result <= 3));


            switch (result)
            {
                case 1:
                    difficulty[0] = 1;
                    difficulty[1] = 11;
                    difficulty[2] = 6;
                    break;
                case 2:
                    difficulty[0] = 1;
                    difficulty[1] = 26;
                    difficulty[2] = 5;
                    break;
                case 3:
                    difficulty[0] = 1;
                    difficulty[1] = 51;
                    difficulty[2] = 3;
                    break;
                default:
                    difficulty[0] = 1;
                    difficulty[1] = 11;
                    difficulty[2] = 6;
                    break;
            }

            return difficulty;

        }

        //Check guess against generated number and give clue if too high/low
        private static void CheckGuess(int guess, int number)
        {
            Random random = new Random();

            if (guess == number)
            {
                Console.WriteLine("Wohoo! Du klarade det!");
                Restart();
            }
            else if (guess > number)
            {

                switch (random.Next(1, 4))
                {
                    case 1:
                        Console.WriteLine("Haha! Det var för högt!");
                        break;
                    case 2:
                        Console.WriteLine("Tyvärr, du gissade för högt!");
                        break;
                    case 3:
                        Console.WriteLine("Bra gissat, men det var för högt");
                        break;
                    default:
                        Console.WriteLine("För högt!");
                        break;
                }

            }
            else if (guess < number)
            {
                
                switch (random.Next(1, 4))
                {
                    case 1:
                        Console.WriteLine("Haha! Det var för lågt!");
                        break;
                    case 2:
                        Console.WriteLine("Tyvärr, du gissade för lågt!");
                        break;
                    case 3:
                        Console.WriteLine("Bra gissat, men det var för lågt");
                        break;
                    default:
                        Console.WriteLine("För lågt!");
                        break;
                }
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
            else if (input == ConsoleKey.N)
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