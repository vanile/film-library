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

        public void SaveToFile(SortableBindingList<Film> DBToStore, string FileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(SortableBindingList<Film>));
            var serializer = new XmlSerializer(typeof(SortableBindingList<Film>));
            using (Stream str = File.Create(FileName))
                ser.Serialize(str, DBToStore);
        }

        public SortableBindingList<Film> LoadFromFile(string FileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(SortableBindingList<Film>));
            try 
            {
                using (Stream str = File.Open(FileName, FileMode.Open))
                    return (SortableBindingList<Film>)ser.Deserialize(str);
            }
            catch (FileNotFoundException e)
            {

            }
            return null;
        }

        public void SaveToText(SortableBindingList<Film> bs, string fileName)
        {
            foreach (Film film in bs)
            {
                using (System.IO.StreamWriter write = new StreamWriter(fileName))
                {
                    write.WriteLine(film.Name);
                    write.WriteLine("\t" + film.Rating);
                }
            }
        }
    }
}
