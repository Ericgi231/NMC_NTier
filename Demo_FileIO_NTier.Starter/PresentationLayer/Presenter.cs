using Demo_FileIO_NTier.BusinessLogicLayer;
using Demo_FileIO_NTier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_FileIO_NTier.PresentationLayer
{
    class Presenter
    {
        static CharacterBLL _charactersBLL;

        public Presenter(CharacterBLL characterBLL)
        {
            _charactersBLL = characterBLL;
            ManageApplicationLoop();
        }

        private void ManageApplicationLoop()
        {
            DisplayWelcomeScreen();
            DisplayListOfCharacters();
            DisplayClosingScreen();
        }

        static void DisplayHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine($"\n\t{headerText}\n");
        }

        static void DisplayContinuePrompt()
        {
            Console.WriteLine($"\n\tPress any key to continue.");
            Console.ReadKey();
        }

        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine($"\n\tWelcome");

            DisplayContinuePrompt();
        }

        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine($"\n\tGood Bye");

            DisplayContinuePrompt();
        }

        private void DisplayCharacterTable(List<Character> characters)
        {
            StringBuilder columnHeader = new StringBuilder();

            columnHeader.Append("\t");
            columnHeader.Append("Id".PadRight(8));
            columnHeader.Append("Full Name".PadRight(25));

            Console.WriteLine(columnHeader.ToString());

            characters = characters.OrderBy(c => c.Id).ToList();
            foreach (Character character in characters)
            {
                StringBuilder characterInfo = new StringBuilder();

                characterInfo.Append("\t");
                characterInfo.Append(character.Id.ToString().PadRight(8));
                characterInfo.Append(character.FullName().PadRight(25));

                Console.WriteLine(characterInfo.ToString());
            }
        }

        private void DisplayListOfCharacters()
        {
            bool success;
            string message;

            List<Character> characters = _charactersBLL.GetCharacters(out success, out message) as List<Character>;


            DisplayHeader("List of Characters");

            if (success)
            {
                characters = characters.OrderBy(c => c.Id).ToList();
                DisplayCharacterTable(characters);
            }
            else
            {
                Console.WriteLine(message);
            }

            DisplayContinuePrompt();
        }

    }
}
