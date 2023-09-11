using UnityEngine;
using VG;


public class CheckPurchase_Event : VG.Event
{
    [SerializeField] private IapButton _iapButton;


    protected override void Subscribe()
    {
        Iap.onPurchased += OnPurchased;
    }

    protected override void Unsubscribe()
    {
        Iap.onPurchased -= OnPurchased;
    }

    private void OnPurchased(string key_product, bool success)
    {
        if (_iapButton.productKey != key_product) return;

        if (success) _iapButton.button.image.color = Color.green;
        else _iapButton.button.image.color = Color.red;
    }



}
