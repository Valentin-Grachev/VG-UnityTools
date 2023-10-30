using System.Collections.Generic;
using UnityEngine;


namespace VG
{
    public class Sources : Initializable
    {
        [System.Serializable]
        private struct Source
        {
            public string id;
            public Object source;
        }

        [SerializeField] private List<Source> _sources;

        private static Dictionary<string, object> sources;


        public override void Initialize()
        {
            sources = new Dictionary<string, object>();
            foreach (var item in _sources) sources.Add(item.id, item.source);

            CompleteInitializing();
        }

        public static object Get(string id) => sources[id];

        protected override void OnInitialized() { }
    }
}


