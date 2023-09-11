using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace VG
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private List<Initializable> _initializables;
        [SerializeField] private List<Initializable> _waitInitializations;


        private void Awake()
        {
            foreach (var item in _initializables) item.Initialize();

            StartCoroutine(WaitInitializing());
        }


        private IEnumerator WaitInitializing()
        {
            bool allInitialized = false;

            while (!allInitialized)
            {
                allInitialized = true;
                foreach (var waitInitialization in _waitInitializations)
                    if (!waitInitialization.initialized) allInitialized = false;

                yield return null;
            }

            
            if (allInitialized) SceneManager.LoadScene(1);
        }




    }
}


