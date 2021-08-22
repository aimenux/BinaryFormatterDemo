using System.Runtime.Serialization;

namespace App.Models.ThirdPartySerialization
{
    public class AddressSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var address = (Address) obj;
            info.AddValue(nameof(Address.City), address.City);
            info.AddValue(nameof(Address.Country), address.Country);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var address = (Address) obj;
            address.City = info.GetString(nameof(Address.City));
            address.Country = info.GetString(nameof(Address.Country));
            return address;
        }
    }
}