using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureQueueLibrary.MessageSerializer
{
    class JsonMessageSerializer : IMessageSerializer
    {
        public T Deserialize<T>(string message)
        {
            var obj = JsonConvert.DeserializeObject<T>(message);
            return obj;
        }

        public string Serialize<T>(T obj)
        {
            string message = JsonConvert.SerializeObject(obj);
            return message;
        }
    }
}
