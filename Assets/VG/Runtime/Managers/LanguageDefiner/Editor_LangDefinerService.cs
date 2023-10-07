using UnityEngine;


namespace VG
{
    public class Editor_LangDefinerService : LangDefinerService
    {
        [SerializeField] private Language _selectedLanguage;


        public override bool supported => Environment.editor;

        public override Language GetLanguage() => _selectedLanguage;

        public override void Initialize() => CompleteInitializing();

        protected override void OnInitialized() { }
    }
}




