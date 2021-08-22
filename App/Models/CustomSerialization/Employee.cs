using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.Json;
using App.Extensions;

namespace App.Models.CustomSerialization
{
    [Serializable]
    public class Employee : ISerializable
    {
        public Employee()
        {
        }

        private Employee(SerializationInfo info, StreamingContext context)
        {
            Id = info.GetInt64(nameof(Id));
            FirstName = info.GetString(nameof(FirstName));
            LastName = info.GetString(nameof(LastName));
            Title = info.GetString(nameof(Title));
            Address = info.GetValue<Address>(nameof(Address));
        }

        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public Address Address { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Id), Id);
            info.AddValue(nameof(FirstName), FirstName);
            info.AddValue(nameof(LastName), LastName);
            info.AddValue(nameof(Title), Title);
            info.AddValue(nameof(Address), Address);
        }

        public override string ToString()
        {
            var json = JsonSerializer.Serialize(this);
            return json;
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
            ConsoleColor.Yellow.WriteLine($"Calling {callerName} for type {nameof(Employee)}");
        }
    }
}
