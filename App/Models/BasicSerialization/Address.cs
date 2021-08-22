using System;

namespace App.Models.BasicSerialization
{
    [Serializable]
    public class Address
    {
        public string City { get; set; }

        public string Country { get; set; }
    }
}