using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VG
{
    public class Test_IapService : IapService
    {
        public override bool supported => true;

        public override void Consume(string key_product)
        {
            throw new NotImplementedException();
        }

        public override string GetPriceString(string key_product)
        {
            return "<test price>";
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override void InitializeProducts(List<Iap.Product> products)
        {
            throw new NotImplementedException();
        }

        public override void Purchase(string key_product, Action<bool> onSuccess)
        {
            throw new NotImplementedException();
        }

        protected override void OnInitialized()
        {
            throw new NotImplementedException();
        }
    }
}



