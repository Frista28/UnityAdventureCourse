using _27_28.Scripts.Wallet.Handler;
using _27_28.Scripts.Wallet.UI;
using UnityEngine;

namespace _27_28.Scripts.Wallet.Bootstrap
{
    public class WalletGameBootstrap : MonoBehaviour
    {
        [SerializeField] private InputHandler _inputHandler;
        [SerializeField] private WalletUI _walletUI;
        
        private Wallet _wallet;

        private void Awake()
        {
            _wallet = new Wallet();
        }

        private void Start()
        {
            _walletUI.Init(_wallet);
            _inputHandler.Init(_wallet);
        }
    }
}