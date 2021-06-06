using System.Collections;
using UnityEngine;

namespace Code
{
    public sealed class Coroutines:MonoBehaviour
    {

        public static Coroutines instance
        {
            get
            {
                if (m_instance == null)
                {
                    var obj = new GameObject("Coroutine");
                   m_instance = obj.AddComponent<Coroutines>();
                }

                return m_instance;
            }
        }

        private static Coroutines m_instance;
        public static Coroutine StartCoroutin(IEnumerator coroutine)
        {
            return instance.StartCoroutine(coroutine);
        }
    }
}