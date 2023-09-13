using static VG.Saves;


namespace VG
{
    public static class SaveCreator
    {
        
        public static void Create()
        {
            new ItemInt(Key_Save.money, 100);
            new ItemBool(Key_Save.ads_enabled, true);
            new ItemString(Key_Save.test_string, "test_");
            new ItemFloat(Key_Save.test_float, 0f);
        }


    }
}


