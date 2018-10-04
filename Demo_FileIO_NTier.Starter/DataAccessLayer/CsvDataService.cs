using Demo_FileIO_NTier.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_FileIO_NTier.Starter.DataAccessLayer
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
            List<String> characterStrings = new List<string>();
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

        private Character CharacterObjectBuilder(string characterString)
        {
            
        }

        public void WriteAll(IEnumerable<Character> characters)
        {
            
        }
    }
}
