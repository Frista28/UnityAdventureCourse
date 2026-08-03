using System;

namespace _27_28.Scripts.Wallet
{
    public interface IReadOnlyCurrency
    {
        public event Action<int> AmountChanged;
        
        public int Amount { get; }
    }
}