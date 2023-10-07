using System.Collections.Generic;
using UnityEngine;


namespace VG
{
    [CreateAssetMenu(menuName = "VG/Localization/Strings", fileName = "Strings")]
    public class Strings_LocalizedData : LocalizedData<String_Translation> 
    {
        [SerializeField] private List<string> _tableKeys;


        public override void LoadData(Dictionary<string, Table> tables)
        {
            _translations = new List<String_Translation>();

            foreach (var tableKey in _tableKeys)
            {
                if (tables.ContainsKey(tableKey))
                {
                    var table = tables[tableKey];

                    for (int i = 1; i < table.rows; i++)
                    {
                        var translation = new String_Translation();
                        translation.key = table.Get(row: i, column: 0);
                        translation.ru = table.Get(row: i, column: 1);
                        translation.en = table.Get(row: i, column: 2);

                        _translations.Add(translation);
                    }
                }
            }

        }


    }
}


