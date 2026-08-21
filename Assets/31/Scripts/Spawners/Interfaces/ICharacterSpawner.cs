namespace _31.Scripts.Spawners.Interfaces
{
    public interface ICharacterSpawner<out TCharacter> where TCharacter : Characters.Character
    {
        public TCharacter Spawn();
    }
}