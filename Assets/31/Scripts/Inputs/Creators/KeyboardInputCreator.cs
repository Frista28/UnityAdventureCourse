using _31.Scripts.Inputs.Interfaces;

namespace _31.Scripts.Inputs.Creators
{
    public class KeyboardInputCreator
    {
        public IMovementInput Create() => new KeyboardMovementInput();
    }
}