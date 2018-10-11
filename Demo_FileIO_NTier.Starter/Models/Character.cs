using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Demo_FileIO_NTier.Models
{
    public class RootObject
    {
        public CharacterContainer Characters { get; set; }
    }

    public class CharacterContainer
    {
        public List<Character> Character { get; set; }
    }

    public class Character
    {
        public enum GenderType { NOTSPECIFIED, MALE, FEMALE }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
