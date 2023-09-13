using VG.YandexGames;



namespace VG
{
    public class YandexGames_ReviewService : ReviewService
    {
        public override bool supported =>
            Platform.gameStore == Platform.GameStore.YandexGames
            && Platform.system == Platform.System.WebGL && !Platform.editor;


        public override void Initialize() => CompleteInitializing();

        protected override void OnInitialized() { }

        public override void Request() => YG_Review.Request();

        
    }
}


