using VG.YandexGames;



namespace VG
{
    public class YandexGames_ReviewService : ReviewService
    {
        public override bool supported =>
            Environment.gameStore == Environment.GameStore.YandexGames
            && Environment.platform == Environment.Platform.WebGL && !Environment.editor;


        public override void Initialize() => CompleteInitializing();

        protected override void OnInitialized() { }

        public override void Request() => YG_Review.Request();

        
    }
}


