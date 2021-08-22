using System.Runtime.Serialization;
using App.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace App.Serializers
{
    public class ThirdPartyBinarySerializer : BinarySerializer
    {
        public ThirdPartyBinarySerializer(ISurrogateSelector selector, IOptions<Settings> options, ILogger logger) : base(options, logger)
        {
            Formatter.SurrogateSelector = selector;
        }
    }
}