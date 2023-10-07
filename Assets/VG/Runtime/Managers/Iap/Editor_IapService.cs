using System;
using System.Collections.Generic;
using VG.Internal;


namespace VG
{
    public class Editor_IapService : IapService
    {
        public override bool supported => Environment.editor;

        public override void Consume(string key_product) => Core.LogEditor("Consumed: " + key_product);

        public override void DeletePurchases() => Core.LogEditor("Purchases deleted.");


        public override string GetPriceString(string key_product) => "<editor mode>";


        public override void Initialize() => CompleteInitializing();

        public override void InitializeProducts(List<Iap.Product> products)
        {
            foreach (var product in products) 
                product.Initialize(0);
        }

        public override void Purchase(string key_product, Action<bool> onSuccess)
        {
            Core.LogEditor("Success purchased: " + key_product);
            onSuccess?.Invoke(true);
        }

        protected override void OnInitialized() { }
    }
}



