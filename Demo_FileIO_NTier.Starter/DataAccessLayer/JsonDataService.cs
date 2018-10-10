using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_FileIO_NTier.Models;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Demo_FileIO_NTier.DataAccessLayer
{
    class JsonDataService : IDataService
    {
        private string _dataFilePath;

        public JsonDataService()
        {
            _dataFilePath = DataSettings.dataFilePath;
        }

        public IEnumerable<Character> ReadAll()
        {
            List<Character> characters = new List<Character>();
            string json = File.ReadAllText(_dataFilePath);

            try
            {
                characters = JsonConvert.DeserializeObject<List<Character>>(json);
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
