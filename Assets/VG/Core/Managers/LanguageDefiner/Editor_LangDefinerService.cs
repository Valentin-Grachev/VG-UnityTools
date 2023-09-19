using UnityEngine;


namespace VG
{
    public class Editor_LangDefinerService : LangDefinerService
    {
        [SerializeField] private LangDefiner.Language _selectedLanguage;


        public override bool supported => Environment.editor;

        public override LangDefiner.Language GetLanguage() => _selectedLanguage;

        public override void Initialize() => CompleteInitializing();

        protected override void OnInitialized() { }
    }
}




