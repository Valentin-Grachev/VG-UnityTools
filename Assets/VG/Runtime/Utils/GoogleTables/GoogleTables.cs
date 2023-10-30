using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



namespace VG
{
    public class GoogleTables : Initializable
    {
        [SerializeField] private bool _requestDataBeforeStart; public bool requestDataBeforeStart => _requestDataBeforeStart;
        [SerializeField] private List<Table> _tables;
        [SerializeField] private List<LoadableFromTable> _loadables;

        private Dictionary<string, Table> tables;

        private static GoogleTables instance;

        public override void Initialize()
        {
            instance = this;

            if (_requestDataBeforeStart) RequestData();
            else CompleteInitializing();
        }

        public static void LoadData() => instance.RequestData();

        [Button("Open First Table")]
        private void OpenTableURL() => Application.OpenURL(_tables[0].checkUrl);



        [Button("Load Data")]
        private void RequestData()
        {
            tables = new Dictionary<string, Table>();

            foreach (var table in _tables)
            {
                tables.Add(table.key, table);
                StartCoroutine(table.RequestData());
            }

            StartCoroutine(WaitData());
        }


        IEnumerator WaitData()
        {
            bool ready = false;
            bool dataError = false;

            while (!ready)
            {
                ready = true;

                foreach (var table in _tables)
                {
                    if (!table.dataAccepted) ready = false;
                    else if (table.error) dataError = true;
                }
                yield return null;
            }

            if (dataError) throw new System.Exception("Table data error!");

            foreach (var loadable in _loadables)
            {
#if UNITY_EDITOR
                EditorUtility.SetDirty(loadable);
#endif
                loadable.HandleData(tables);
            }
            
                

            CompleteInitializing();
        }




        protected override void OnInitialized() { }

    }

}



