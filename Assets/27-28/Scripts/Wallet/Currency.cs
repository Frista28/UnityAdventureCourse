using System;

namespace _27_28.Scripts.Wallet
{
    public class Currency : IReadOnlyCurrency
    {
        public event Action<int> AmountChanged;
        
        public CurrencyType Type { get; }
    
        public int Amount { get; private set; }

        public Currency(CurrencyType type, int value)
        {
            Type = type;

            ValidateValue(value);
            
            Amount = value;
        }

        public void Add(int value)
        {
            ValidateValue(value);
            
            if (value == 0)
                return;
        
            Amount += value;
            AmountChanged?.Invoke(Amount);
        }

        public bool TrySpend(int value)
        {
            ValidateValue(value);
            
            if (value == 0)
                return true;
        
            if (Amount < value)
                return false;
        
            Amount -= value;
            AmountChanged?.Invoke(Amount);
            return true;
        }
        
        private void ValidateValue(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be greater than or equal to zero");
        }
    }
}
