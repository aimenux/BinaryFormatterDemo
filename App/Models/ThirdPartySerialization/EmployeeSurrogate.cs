using System.Runtime.Serialization;
using App.Extensions;

namespace App.Models.ThirdPartySerialization
{
    public class EmployeeSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var employee = (Employee) obj;
            info.AddValue(nameof(Employee.Id), employee.Id);
            info.AddValue(nameof(Employee.FirstName), employee.FirstName);
            info.AddValue(nameof(Employee.LastName), employee.LastName);
            info.AddValue(nameof(Employee.Title), employee.Title);
            info.AddValue(nameof(Employee.Address), employee.Address);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var employee = (Employee) obj;
            employee.Id = info.GetInt64(nameof(Employee.Id));
            employee.FirstName = info.GetString(nameof(Employee.FirstName));
            employee.LastName = info.GetString(nameof(Employee.LastName));
            employee.Title = info.GetString(nameof(Employee.Title));
            employee.Address = info.GetValue<Address>(nameof(Employee.Address));
            return employee;
        }
    }
}