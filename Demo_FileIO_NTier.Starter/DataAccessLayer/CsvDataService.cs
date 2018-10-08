using Demo_FileIO_NTier.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_FileIO_NTier.DataAccessLayer
{
    class CsvDataService : IDataService
    {
        private string _dataFilePath;

        public CsvDataService()
        {
            _dataFilePath = DataSettings.dataFilePath;
        }

        public IEnumerable<Character> ReadAll()
        {
            List<string> characterStrings = new List<string>();
            List<Character> characters = new List<Character>();

            try
            {
                StreamReader sr = new StreamReader(_dataFilePath);
                using (sr)
                {
                    while (!sr.EndOfStream)
                    {
                        characterStrings.Add(sr.ReadLine());
                    }
                }
                foreach (string characterString in characterStrings)
                {
                    characters.Add(CharacterObjectBuilder(characterString));
                }
            }
            catch (Exception)
            {
                throw;
            }

            return characters;
        }

        public void WriteAll(IEnumerable<Character> characters)
        {
            try
            {
                StreamWriter sw = new StreamWriter(_dataFilePath);
                using (sw)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Clear();
                    foreach (Character character in characters)
                    {
                        sb.AppendLine(CharacterStringBuilder(character));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Character CharacterObjectBuilder(string characterString)
        {
            const char DL = ',';
            string[] properties = characterString.Split(DL);

            Character character = new Character()
            {
                Id = Convert.ToInt32(properties[0]),
                LastName = properties[1],
                FirstName = properties[2],
                Address = properties[3],
                City = properties[4],
                State = properties[5],
                Zip = properties[6],
                Age = Convert.ToInt32(properties[7]),
                Gender = (Character.GenderType)Enum.Parse(typeof(Character.GenderType), properties[8])
            };

            return character;
        }

        private string CharacterStringBuilder(Character characterObject)
        {
            const string DEL = ",";
            string characterString;

            characterString =
                characterObject.Id + DEL +
                characterObject.LastName + DEL +
                characterObject.FirstName + DEL +
                characterObject.Address + DEL +
                characterObject.City + DEL +
                characterObject.State + DEL +
                characterObject.Zip + DEL +
                characterObject.Age + DEL +
                characterObject.Gender;

            return characterString;
        }
    }
}
