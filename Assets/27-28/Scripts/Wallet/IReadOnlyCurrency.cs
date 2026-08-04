using System;

namespace _27_28.Scripts.Wallet
{
    public interface IReadOnlyCurrency
    {
        public event Action<int> AmountChanged;
        
        CurrencyType Type { get; }
        
        public int Amount { get; }
    }
}