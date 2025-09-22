using UnityEngine;

namespace Utils
{
    public static class MonoBehaviourExtensions
    {
        public static void AssertReference<T>(this MonoBehaviour monoBehaviour, T reference) where T : class
        {
            if (reference == null)
            {
                throw new System.NullReferenceException($"Object {monoBehaviour.name} reference to a {typeof(T)} is not assigned in the inspector. Please assign it before playing.");
            }
        }
    }
}
