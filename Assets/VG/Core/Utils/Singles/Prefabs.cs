using System.Collections.Generic;
using UnityEngine;


namespace VG
{
    public class Prefabs : Initializable
    {
        [System.Serializable]
        private struct PrefabUnit
        {
            public string id;
            public GameObject prefab;
        }

        [SerializeField] private List<PrefabUnit> _prefabs;

        private static Dictionary<string, GameObject> prefabs;


        public override void Initialize()
        {
            prefabs = new Dictionary<string, GameObject>();
            foreach (var item in _prefabs) prefabs.Add(item.id, item.prefab);

            CompleteInitializing();
        }

        public static GameObject Get(string id) => prefabs[id];

        protected override void OnInitialized() { }
    }
}


