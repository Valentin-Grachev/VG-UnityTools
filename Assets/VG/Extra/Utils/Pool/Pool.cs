using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VG
{
    public class Pool : MonoBehaviour
    {
        private static Transform container;

        private static List<PoolObject> poolObjects = new List<PoolObject>();

        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            container = transform;
        }


        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            poolObjects.Clear();
        }

        public static GameObject Get(PoolObject poolObject, Vector2 position)
        {
            foreach (var oldPoolObject in poolObjects)
                if (oldPoolObject.hash == poolObject.hash && !oldPoolObject.gameObject.activeInHierarchy)
                {
                    oldPoolObject.gameObject.SetActive(true);
                    oldPoolObject.transform.position = position;
                    return oldPoolObject.gameObject;
                }

            PoolObject newPoolObject = Instantiate(poolObject, container);
            poolObjects.Add(newPoolObject);
            newPoolObject.transform.position = position;

            return newPoolObject.gameObject;
        }


    }
}



