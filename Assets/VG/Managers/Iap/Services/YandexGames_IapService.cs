using System;
using System.Collections;
using System.Collections.Generic;
using VG.YandexGames;
using UnityEngine;


namespace VG
{
    public class YandexGames_IapService : IapService
    {
        private List<string> _purchasedProductIds;
        private Dictionary<string, string> _productPrices;



        public override bool supported =>
            Platform.gameStore == Platform.GameStore.YandexGames
            && Platform.system == Platform.System.WebGL && !Platform.editor;


        public override void Consume(string key_product) => YG_Purchases.Consume(key_product);

        public override string GetPriceString(string key_product) => _productPrices[key_product];

        public override void Initialize() => StartCoroutine(PurchaseInitializing());


        private IEnumerator PurchaseInitializing()
        {
            while (!YG_Purchases.available)
            {
                yield return new WaitForSecondsRealtime(0.1f);
                YG_Purchases.InitializePayments();
            }

            YG_Purchases.GetPurchasedProducts((purchasedProductIds) 
                => _purchasedProductIds = purchasedProductIds);

            YG_Purchases.GetPrices((productPrices) => _productPrices = productPrices);


            while (_purchasedProductIds == null || _productPrices == null) 
                yield return null;

            CompleteInitializing();
        }



        public override void InitializeProducts(List<Iap.Product> products)
        {
            foreach (var product in products)
            {
                int productPurchaseQuantity = 0;

                foreach (var purchasedProductId in _purchasedProductIds)
                    if (product.key == purchasedProductId) productPurchaseQuantity++;

                product.Initialize(productPurchaseQuantity);
            }
        }

        public override void Purchase(string productKey, Action<bool> onSuccess)
            => YG_Purchases.Purchase(productKey, onSuccess);


        protected override void OnInitialized() { }
    }
}


