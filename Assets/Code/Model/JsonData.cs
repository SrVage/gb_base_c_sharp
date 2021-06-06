using UnityEngine;
using System.IO;

namespace Code
{
    public class JsonData<T> : IData<T>
    {
        public void Save(T [] data, string path = null)
        {
            string[] str = new string[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                str[i] = Cryptography.CryptoXOR(JsonUtility.ToJson(data[i]));
            }
            
            File.WriteAllLines(path, str);
        }

        public T [] Load(string path = null)
        {
            var str = File.ReadAllLines(path);
            T[] t = new T[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                t[i] = JsonUtility.FromJson<T>(Cryptography.DeCryptoXOR(str[i]));
            }

            return t;
        }
    }
}