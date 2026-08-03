using System.Collections.Generic;

namespace _27_28.Scripts.Wallet
{
    public class Wallet
    {
        private readonly Dictionary<CurrencyType, Currency> _currencies;

        public Wallet()
        {
            _currencies = new Dictionary<CurrencyType, Currency>
            {
                { CurrencyType.Coin, new Currency(CurrencyType.Coin, 0) },
                { CurrencyType.Diamond, new Currency(CurrencyType.Diamond, 0) },
                { CurrencyType.Energy, new Currency(CurrencyType.Energy, 0) },
            };
        }
        
        public IReadOnlyCurrency GetCurrency(CurrencyType type) => GetCurrencyInternal(type);

        public void Add(CurrencyType type, int value) => GetCurrencyInternal(type).Add(value);

        public bool TrySpend(CurrencyType type, int amount) => GetCurrencyInternal(type).TrySpend(amount);

        private Currency GetCurrencyInternal(CurrencyType type)
        {
            if (!_currencies.TryGetValue(type, out var currency))
            {
                throw new KeyNotFoundException(
                    $"Currency {type} not found");
            }

            return currency;
        }
    }
}