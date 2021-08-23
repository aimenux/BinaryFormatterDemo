using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using App.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace App.Serializers
{
    public class BinarySerializer : IBinarySerializer
    {
        private readonly IOptions<Settings> _options;
        protected readonly IFormatter Formatter;
        private readonly ILogger _logger;

        private string FileName => _options.Value.FileName;

        public BinarySerializer(IOptions<Settings> options, ILogger logger)
        {
            Formatter = new BinaryFormatter();
            _options = options;
            _logger = logger;
        }

        public void Serialize<T>(T obj)
        {
            try
            {
                using var stream = new FileStream(FileName, FileMode.Create);
                Formatter.Serialize(stream, obj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to serialize object {@obj}", obj);
            }
        }

        public T Deserialize<T>()
        {
            try
            {
                using var stream = new FileStream(FileName, FileMode.Open);
                var obj = (T) Formatter.Deserialize(stream);
                return obj;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to deserialize binary data {filename}", FileName);
            }

            return default(T);
        }
    }
}
