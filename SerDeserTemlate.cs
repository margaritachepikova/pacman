using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Курсовой
{
    static class SerDeserTemlate<T>
    {
        public static BinaryFormatter formatter = new BinaryFormatter();
        public static void Serialize(string path, T data)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, data);
            }
        }
        public static T Deserialize(string path)
        {
            T res;
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                res = (T)formatter.Deserialize(fs);
            }
            return res;
        }
    }
}
