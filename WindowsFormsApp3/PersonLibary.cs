using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApp3
{
    public class PersonLibary
    {
        private List<Person> personlist = new List<Person>();


        public int Count
        {
            get { return personlist.Count; }
        }

        public Person this[int index]
        { 
            get
            {
                return personlist[index];
            }
        }
        public PersonLibary()
        {

        }
        public void AddPerson(Person person) 
        {
            personlist.Add(person);
        }

        public void RemovePerson(int index) 
        {
        personlist.RemoveAt(index);
        }

        public void Save(string filename) 
        {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            using (var fstream = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fstream, personlist);
            }

        }

        public void Load(string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            using (var fstream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                personlist = xmlSerializer.Deserialize(fstream) as List<Person>;
            }
        }
    }
}
