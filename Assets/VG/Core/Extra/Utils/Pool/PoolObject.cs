using UnityEngine;
using NaughtyAttributes;
using System.Linq;

namespace VG
{
    public class PoolObject : MonoBehaviour
    {
        [SerializeField] private string _hash;
        public string hash => _hash;


        [Button("Generate hash key")]
        private void GenerateHash()
        {
            _hash = RandomString(6);
        }


        private string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Range(0, s.Length)]).ToArray());
        }

        public void Disable() => gameObject.SetActive(false);

    }
}


