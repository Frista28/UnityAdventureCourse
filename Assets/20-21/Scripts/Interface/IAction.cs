namespace _20_21.Scripts.Interface
{
    public interface IAction
    {
        public bool CanExecute();
        public void Execute();
    }
}