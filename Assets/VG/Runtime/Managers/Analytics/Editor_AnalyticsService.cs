using System.Collections.Generic;
using UnityEngine;
using VG.Internal;


namespace VG
{
    public class Editor_AnalyticsService : AnalyticsService
    {
        [SerializeField] private bool _tracking;


        public override bool supported => Environment.editor;

        public override void Initialize() => CompleteInitializing();

        public override void Track(string key_analytics, Dictionary<string, object> parameters)
        {
            if (!_tracking) return;

            string message = "Event tracked: " + key_analytics;
            foreach (var parameter in parameters)
                message += "\n" + parameter.Key + ": " + parameter.Value.ToString();

            Core.LogEditor(message);
        }

        protected override void OnInitialized() { }
    }
}


