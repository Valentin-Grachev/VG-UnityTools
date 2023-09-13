using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VG
{
    
    public class IapButton : ButtonClick
    {
        [SerializeField] private string _key_product; public string productKey => _key_product;
        [SerializeField] private UnityEvent<string> _onHandlePrice;


        private void OnEnable() => HandlePrice();


        private void HandlePrice() => _onHandlePrice?.Invoke(Iap.GetPriceString(_key_product));



        protected override void OnClick() => Iap.Purchase(_key_product);
    }
}



