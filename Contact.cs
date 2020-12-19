using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public struct Contact
    {
        public string Name;
        public string Number;

        public override string ToString()
        {
            return $"{Name} {Number}";
        }
    }

    public static class ContactHelper
    {
        public static Contact? ContactParse(this string input)
        {
            var data = input.Split(' ');
            // TODO: Validate Contact 
            if (data.Length < 2)
                return null;

            Contact contact = new Contact();
            contact.Name = data[0];
            contact.Number = data[1];
            return contact;
        }
    }
}
