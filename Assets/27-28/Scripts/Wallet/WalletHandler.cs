using UnityEngine;

namespace _27_28.Scripts.Wallet
{
    public class WalletHandler : MonoBehaviour
    {
        public Wallet Wallet { get; private set; }

        public void Awake()
        {
            Wallet = new Wallet();
        }
    }
}