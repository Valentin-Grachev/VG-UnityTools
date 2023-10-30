using System.Collections.Generic;
using UnityEngine;


namespace VG
{
    public abstract class LoadableFromTable : ScriptableObject
    {
        [SerializeField] private List<string> _includedTableKeys;


        public void HandleData(Dictionary<string, Table> allTables)
        {
            var includedTables = new List<Table>();

            foreach (var tableKey in _includedTableKeys)
                if (allTables.ContainsKey(tableKey))
                    includedTables.Add(allTables[tableKey]);

            LoadData(includedTables);
        }


        protected abstract void LoadData(List<Table> includedTables);

}
}


