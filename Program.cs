using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    class Program
    {
        static private List<Contact> contacts;

        static Contact AddContact(Contact contact)
        {
            contacts.Add(contact);
            return contact;
        }

        const string Path = "PhoneBook.txt";
        const string PathXML = "PhoneBookXML.txt";
        const string PathXML2 = "PhoneBookXML2.txt";
        static void Save()
        {
            using (StreamWriter sr = new StreamWriter(Path))
            {
                foreach (Contact c in contacts)
                {
                    sr.WriteLine(c);
                }
            }
        }
        static void SaveToXML()
        {
            var xmlSerialiser = new XmlSerializer(typeof(Contact));
            using (StreamWriter sr = new StreamWriter(PathXML))
            {
                foreach (Contact c in contacts)
                {
                    xmlSerialiser.Serialize(sr, c);
                }
            }
        }
        static void SaveToXML2()
        {
            var xmlSerialiser = new XmlSerializer(typeof(List<Contact>));
            using (StreamWriter sr = new StreamWriter(PathXML2))
            {
                xmlSerialiser.Serialize(sr, contacts);
            }
        }

        public static List<Contact> Load(string path)
        {
            List<Contact> loadedContacts = new List<Contact>();
            using (StreamReader sr = new StreamReader(path))
            {
                while(!sr.EndOfStream)
                {
                    string input = sr.ReadLine();
                    var contact = input.ContactParse();
                    if(contact != null)
                    {
                        loadedContacts.Add(contact.Value);
                    }
                }
            }
            return loadedContacts;
        }

        static void Main(string[] args)
        {
            contacts = new List<Contact>();

            Contact IvanPetrovich;
            IvanPetrovich.Name = "Ivan Petrovich";
            IvanPetrovich.Number = "345248325 сброс 103";
            AddContact(IvanPetrovich);
            AddContact(IvanPetrovich);
            AddContact(IvanPetrovich);
            Save();
            // Load will cause some parse issues
            SaveToXML();
            SaveToXML2();
        }
    }
}
