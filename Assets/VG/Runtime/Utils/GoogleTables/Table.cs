using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using VG.Internal;

namespace VG
{
    [System.Serializable]
    public class Table
    {
        [SerializeField] private string _key; public string key => _key;
        [Space(10)]
        [SerializeField] private string _webId;
        [SerializeField] private string _gid;

        private const string editorName = "VG-Table";


        public bool dataAccepted { get; private set; }
        public bool error { get; private set; }

        public string checkUrl => checkUrlTemplate.Replace("*", _webId) + "#gid=" + _gid;
        public string loadUrl => loadUrlTemplate.Replace("*", _webId) + "&gid=" + _gid;


        private List<List<string>> _cells;


        private const string checkUrlTemplate = "https://docs.google.com/spreadsheets/d/*/edit";
        private const string loadUrlTemplate = "https://docs.google.com/spreadsheets/d/*/export?format=csv";

        public string Get(int row, int column) => _cells[row][column];

        public int rows => _cells.Count;
        public int columns => _cells[0].Count;


        public IEnumerator RequestData()
        {
            dataAccepted = false;
            error = false;

            using (UnityWebRequest request = UnityWebRequest.Get(loadUrl))
            {
                yield return request.SendWebRequest();

                dataAccepted = true;

                if (request.result == UnityWebRequest.Result.Success)
                {
                    string csvData = request.downloadHandler.text;
                    _cells = CsvParcer.Parce(csvData);
                    
                    Debug.Log(csvData);
                    Debug.Log(Core.Prefix(editorName) + Core.Green("Success: ") + _key);
                }
                else
                {
                    error = true;
                    Debug.LogError("Table error: " + request.error);
                }

            }

            yield return null;
        }


        



    }
}



