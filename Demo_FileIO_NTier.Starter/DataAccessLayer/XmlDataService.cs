using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_FileIO_NTier.Models;
using System.IO;
using System.Xml.Serialization;

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
            throw new NotImplementedException();
        }

        public void WriteAll(IEnumerable<Character> characters)
        {
            throw new NotImplementedException();
        }
    }
}
