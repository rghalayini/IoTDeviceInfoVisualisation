using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace IoTDeviceInfoVisualisationApp.Models
{
    public interface IStorage
    {
        Task<Stream> Load(string name);
    }
}