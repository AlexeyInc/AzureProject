using System;
using System.Collections.Generic;
using System.Text;

namespace AzureQueueLibrary.MessageSerializer
{
    public interface IMessageSerializer
    {
        T Deserialize<T>(string message);
        string Serialize<T>(T obj);
    }
}
