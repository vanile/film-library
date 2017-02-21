using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CPP.CS.CS408.FilmLib
{
    class DataIO
    {
        public DataIO()
        {
            
        }

        public void SaveToFile(FilmDB DBToStore, string FileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(FilmDB));
            var serializer = new XmlSerializer(typeof(FilmDB));
            using (Stream str = File.Create(FileName))
                ser.Serialize(str, DBToStore);
        }

        public FilmDB LoadFromFile(string FileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(FilmDB));
            using (Stream str = File.Open(FileName, FileMode.Open))
                return (FilmDB)ser.Deserialize(str);
        }
    }
}
