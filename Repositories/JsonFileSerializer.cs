using System.Text.Json;
using System.Text.Json.Serialization;
using BankApp.IServices;

namespace BankApp.Manager
{
    public class JsonFileSerializer<T> : ISerializer<T>
    {
        private readonly JsonSerializerOptions _options;

        public JsonFileSerializer()
        {
            _options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters = { new JsonStringEnumConverter() }
                // Add custom converters if you have polymorphism or special types.
            };
        }

        /// <summary>
        /// Serialize to a temp file then atomically move to target path.
        /// </summary>
        public void Serialize(T obj, string path)
        {
            var temp = path + ".tmp";

            using (var ms = new MemoryStream())
            {
                JsonSerializer.Serialize(ms, obj, _options);
                ms.Position = 0;
                // Write temp file with exclusive access
                using (var fs = new FileStream(temp, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    ms.CopyTo(fs);
                    fs.Flush(); // try to flush to disk
                }
            }

            // Atomic replace: overwrite destination if it exists
            File.Move(temp, path, overwrite: true);
        }

        public List<T>? DeserializeToList(string path)
        {
            if (!File.Exists(path)) return default;

            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                var obj = JsonSerializer.Deserialize<List<T>>(fs, _options);
                return obj;
            }
            catch (JsonException)
            {
                // defensive: copy corrupt file for inspection and rethrow
                var corruptName = path + ".corrupt." + DateTime.UtcNow.Ticks;
                File.Copy(path, corruptName, overwrite: true);
                throw;
            }
        }
    }
}