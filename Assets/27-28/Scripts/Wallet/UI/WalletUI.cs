using UnityEngine;

namespace _27_28.Scripts.Wallet.UI
{
    public class WalletUI : MonoBehaviour
    {
        [SerializeField] private CurrencyView _currencyViewPrefab;
        
        [SerializeField] private Sprite _coinImage;
        [SerializeField] private Sprite _diamondImage;
        [SerializeField] private Sprite _energyImage;
        
        private Wallet _wallet;

        public void Init(Wallet wallet)
        {
            _wallet = wallet;
            
            foreach (var currency in _wallet.Currencies)
            {
                CreateCurrencyView(currency);
            }
        }

        private void CreateCurrencyView(IReadOnlyCurrency currency)
        {
            CurrencyView currencyView = Instantiate(_currencyViewPrefab, transform);
            currencyView.gameObject.name = currency.Type.ToString();
            currencyView.Init(currency, GetImage(currency.Type));
        }

        private Sprite GetImage(CurrencyType type)
        {
            switch (type)
            {
                case CurrencyType.Coin:
                    return _coinImage;
                case CurrencyType.Diamond:
                    return _diamondImage;
                case CurrencyType.Energy:
                    return _energyImage;
                default:
                    return _coinImage;
            }
        }
    }
}
