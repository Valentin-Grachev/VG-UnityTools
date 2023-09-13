using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


namespace VG.YandexGames
{
    public class YG_Purchases : MonoBehaviour
    {

        public static bool available { get { CheckPaymentsAvailable(); return _paymentsAvailable; } }

        public static void Purchase(string productId, Action<bool> onPurchasedSuccess)
        {
            _onPurchasedSuccess = onPurchasedSuccess;
            RequestPurchasing(productId);
        }

        public static void GetPurchasedProducts(Action<List<string>> onPurchasedProductIdsReceived)
        {
            _onPurchasesReceived = onPurchasedProductIdsReceived;
            RequestPurchasesIds();
        }

        public static void GetPrices(Action<Dictionary<string, string>> onPricesReceived)
        {
            _onPricesReceived = onPricesReceived;
            GetCatalogPrices();
        }


        public static void Consume(string productId) => RequestPurchaseConsuming(productId);


        [DllImport("__Internal")] public static extern void InitializePayments();



        #region Internal

        private static bool _paymentsAvailable = false;


        [DllImport("__Internal")] private static extern void CheckPaymentsAvailable();
        private void HTML_OnPaymentsAvailableChecked(int available) => _paymentsAvailable = Convert.ToBoolean(available);



        private static event Action<bool> _onPurchasedSuccess;
        [DllImport("__Internal")] private static extern void RequestPurchasing(string productId);
        private void HTML_OnPurchaseHandled(int success) => _onPurchasedSuccess?.Invoke(Convert.ToBoolean(success));



        private static event Action<List<string>> _onPurchasesReceived;
        [DllImport("__Internal")] private static extern void RequestPurchasesIds();
        private void HTML_OnPurchasesReceived(string purchasedProductIdsString)
        {
            string[] purchasedProductIds = purchasedProductIdsString.Split(',');
            List<string> purchasedProductIdsList = new List<string>(purchasedProductIds);
            _onPurchasesReceived?.Invoke(purchasedProductIdsList);
        }


        private static event Action<Dictionary<string, string>> _onPricesReceived;
        [DllImport("__Internal")] private static extern void GetCatalogPrices();
        private void HTML_OnPricesReceived(string pricesData)
        {
            var productPrices = new Dictionary<string, string>();

            string[] productPriceStrings = pricesData.Split(';');

            foreach (string productPriceString in productPriceStrings)
            {
                if (productPriceString == string.Empty) continue;

                string[] idPricePair = productPriceString.Split(',');
                string productId = idPricePair[0];
                string price = idPricePair[1];
                productPrices.Add(productId, price);
            }

            _onPricesReceived?.Invoke(productPrices);
        }




        [DllImport("__Internal")] private static extern void RequestPurchaseConsuming(string productId);


        #endregion








    }
}


