using System.Collections.Generic;
using UnityEngine;


namespace VG
{
    [CreateAssetMenu(menuName = "VG/Localization/Strings", fileName = "Strings")]
    public class Strings_LocalizedData : LocalizedData<String_Translation> 
    {
        
        protected override void LoadData(List<Table> includedTables)
        {
            _translations = new List<String_Translation>();
            var dynamicMarker = new String_Translation();
            dynamicMarker.key = "#dynamic";
            _translations.Add(dynamicMarker);

            foreach (var table in includedTables)
            {
                for (int i = 1; i < table.rows; i++)
                {
                    var translation = new String_Translation();
                    translation.key = table.Get(row: i, column: 0);

                    translation.ru = table.Get(row: i, column: 1);
                    translation.en = table.Get(row: i, column: 2);
                    translation.tr = table.Get(row: i, column: 3);

                    _translations.Add(translation);
                }
            }
        }
    }
}


