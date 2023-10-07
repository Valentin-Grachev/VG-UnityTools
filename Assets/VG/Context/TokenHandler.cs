


namespace VG
{
    public static class TokenHandler
    {

        public static void LoadTokens()
        {
            Localization.SetToken(Key_Token.money, Saves.Int[Key_Save.money].Value.ToString());
            Saves.Int[Key_Save.money].onChanged += 
                () => Localization.SetToken(Key_Token.money, Saves.Int[Key_Save.money].Value.ToString());



        }





    }
}


