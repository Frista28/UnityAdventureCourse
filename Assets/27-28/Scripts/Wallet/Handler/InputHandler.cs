using UnityEngine;

namespace _27_28.Scripts.Wallet.Handler
{
    public class InputHandler : MonoBehaviour
    {
        private Wallet _wallet;

        public void Init(Wallet wallet)
        {
            _wallet = wallet;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _wallet.Add(CurrencyType.Coin, 1);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                _wallet.Add(CurrencyType.Diamond, 2);
            if (Input.GetKeyDown(KeyCode.Alpha3))
                _wallet.Add(CurrencyType.Energy, 5);
            
            if (Input.GetKeyDown(KeyCode.Alpha4))
                _wallet.TrySpend(CurrencyType.Coin, 2);
            if (Input.GetKeyDown(KeyCode.Alpha5))
                _wallet.TrySpend(CurrencyType.Diamond, 2);
            if (Input.GetKeyDown(KeyCode.Alpha6))
                _wallet.TrySpend(CurrencyType.Energy, 2);
                
        }
    }
}