

namespace VG.Internal
{
    public static class Core
    {
        private const string debugColor = "#9D68D3";

        public static class Error
        {
            public static void NoSupportedService(string managerName)
            {
                throw new System.Exception(Prefix(managerName) + "No supported service.");
            }
        }

        public static class Message
        {
            public static string Initialized(string managerName) => "Initialized.";
        }

        public static string Prefix(string name)
        {
            if (Platform.editor) return $"<color={Core.debugColor}>{name}: </color>";
            else return $"{name}: ";
        }


    }
}


