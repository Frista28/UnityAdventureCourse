using System;

namespace _29_30.Scripts.Timer.ReactiveUtils
{
    public class ReactiveVariable<T> where T : IEquatable<T>
    {
        public event Action<T> Changed;
        
        private T _value;
        
        public ReactiveVariable() => _value = default(T);
        
        public ReactiveVariable(T value) => _value = value;

        public T Value
        {
            get => _value;
            set
            {
                var oldValue = _value;
                _value = value;
                
                if (!_value.Equals(oldValue))
                    Changed?.Invoke(value);
            }
        }
    }
}