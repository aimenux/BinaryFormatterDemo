using System.Runtime.Serialization;
using App.Models.ThirdPartySerialization;

namespace App.Serializers
{
    public class ThirdPartySurrogateSelector : SurrogateSelector
    {
        public ThirdPartySurrogateSelector()
        {
            AddSurrogate(typeof(Address), new StreamingContext(StreamingContextStates.All), new AddressSurrogate());
            AddSurrogate(typeof(Employee), new StreamingContext(StreamingContextStates.All), new EmployeeSurrogate());
        }
    }
}