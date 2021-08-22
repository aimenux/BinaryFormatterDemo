using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using App.Extensions;

namespace App.Models.CustomSerialization
{
    [Serializable]
    public class Address : ISerializable
    {
        public Address()
        {
        }

        private Address(SerializationInfo info, StreamingContext context)
        {
            City = info.GetString(nameof(City));
            Country = info.GetString(nameof(Country));
        }

        public string City { get; set; }

        public string Country { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(City), City);
            info.AddValue(nameof(Country), Country);
        }

        [OnSerializing]
        internal void OnSerializingMethod(StreamingContext context)
        {
            TraceSerializationProcess();
        }

        [OnSerialized]
        internal void OnSerializedMethod(StreamingContext context)
        {
            TraceSerializationProcess();
        }

        [OnDeserializing]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            TraceSerializationProcess();
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            TraceSerializationProcess();
        }

        private void TraceSerializationProcess([CallerMemberName] string callerName = null)
        {
            ConsoleColor.Yellow.WriteLine($"Calling {callerName} for type {nameof(Address)}");
        }
    }
}