using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _27_28.Scripts.Wallet.UI
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _amountText;
        [SerializeField] private Image _image;
    
        private IReadOnlyCurrency _currency;

        public void Init(IReadOnlyCurrency currency, Sprite sprite = null)
        {
            _currency = currency;
            _currency.AmountChanged += OnAmountChanged;
            UpdateText(_currency.Amount.ToString());
            
            if(sprite != null)
                _image.sprite = sprite;
        }

        private void OnDestroy() => _currency.AmountChanged -= OnAmountChanged;

        private void OnAmountChanged(int amount) => UpdateText(amount.ToString());
    
        private void UpdateText(string text) => _amountText.text = text;
    }
}
