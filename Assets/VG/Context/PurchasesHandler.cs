

namespace VG
{
    public static class PurchasesHandler
    {

        public static void HandlePurchase(string key_product)
        {
            switch (key_product)
            {
                case Key_Product.money_100:
                    Saves.Int[Key_Save.money].Value += 100;
                    break;

                case Key_Product.no_ads:
                    Saves.Bool[Key_Save.ads_enabled].Value = false;
                    break;

            }
        }


    }
}

