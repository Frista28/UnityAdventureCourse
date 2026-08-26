namespace _31.Scripts.Inputs.Interfaces
{
    public interface IWeaponInput
    {
        bool Pressed { get; }
        void PressedReset();
        void Update();
    }
}