using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_FileIO_NTier.Models;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Demo_FileIO_NTier.DataAccessLayer
{
    class XmlDataService : IDataService
    {
        private string _dataFilePath;

        public XmlDataService()
        {
            _dataFilePath = DataSettings.dataFilePath;
        }

        public IEnumerable<Character> ReadAll()
        {
            List<Character> characters = new List<Character>();

            try
            {

                XmlSerializer xs = new XmlSerializer(typeof(List<Character>), new XmlRootAttribute("Characters"));
                StringReader sr = new StringReader(File.ReadAllText(_dataFilePath));

                using (sr)
                {
                    characters = (List<Character>) xs.Deserialize(sr);
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
