using VG.Internal;


namespace VG
{
    public class Editor_ReviewService : ReviewService
    {
        public override bool supported => Platform.editor;

        public override void Initialize() => CompleteInitializing();

        public override void Request()
        {
            Core.LogEditor("Review requested.");
        }

        protected override void OnInitialized() { }
    }
}


