using System;
using System.Text.Json;

namespace App.Models.BasicSerialization
{
    [Serializable]
    public class Employee
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public Address Address { get; set; }

        public override string ToString()
        {
            var json = JsonSerializer.Serialize(this);
            return json;
        }
    }
}
