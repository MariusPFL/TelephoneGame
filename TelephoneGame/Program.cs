using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TelephoneGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playersCount;
            int difficulty;
            Random random = new Random();
            String startText;
            String actualText;
            String inputNumberOfPlayers;


            Char[] vocals = new char[] { 'a', 'e', 'i', 'o', 'u', 'ä', 'ö', 'ü' };
            // Make Consonantslist is a char Array
            Char[] consonants = "bcdfghjklmnpqrstvwxyz".ToCharArray();

            Console.WriteLine("Willkommen beim Telefongame");

            
            do
            {
                Console.WriteLine("Wie viele Spieler gibt es?");
                inputNumberOfPlayers = Console.ReadLine().Trim(' ');
            } while (!inputNumberOfPlayers.All(Char.IsDigit));
            playersCount = Convert.ToInt32(inputNumberOfPlayers);

            do
            {
                Console.WriteLine("Auf einer Skala von 1-5, wie schlecht hören die Spieler? (1-5)");
                difficulty = Convert.ToInt32(Console.ReadLine().Trim(' '));
            } while (difficulty <= 0 || difficulty > 5);

            // Start Text
            Console.WriteLine("Der Ursprungssatz lautet: ");
            startText = Console.ReadLine();
            actualText = startText;



            // MainLoop looping through players
            for (int playersCounter = 0; playersCounter < playersCount; playersCounter++)
            {
                // Loop for Difficulty (How many letters will be replaced)
                for (int y = 0; y < difficulty; y++)
                {
                    Char letter;
                    Char replacingLetter;
                    int position;
                    Boolean isUpper;
                    Boolean isVocal;

                    do
                    {
                        position = random.Next(startText.Length);
                        letter = actualText.ElementAt(position);
                    } while (!Char.IsLetter(letter));

                    // Check if it is UpperCase
                    isUpper = Char.IsUpper(letter);
                    // Check if it is a vocal
                    isVocal = false;

                    foreach (var item in vocals)
                    {
                        if (item == Char.ToLower(letter))
                        {
                            isVocal = true;
                        }
                    }
                    // Replace. Replace is made using a stringbuilder
                    if (isVocal)
                    {
                        replacingLetter = vocals[random.Next(vocals.Length)];
                    }
                    else
                    {
                        replacingLetter = consonants[random.Next(consonants.Length)];
                    }
                    StringBuilder sb = new StringBuilder(actualText);
                    sb[position] = replacingLetter;
                    actualText = sb.ToString();
                }
                // Just for fun
                Thread.Sleep(400);
                // Text will be displayed
                Console.WriteLine($"Spieler {playersCounter} sagt: {actualText}");
            }
            Console.ReadKey();
        }
    }
}
