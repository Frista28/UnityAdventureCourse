using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _27_28.Scripts.Timer
{
    public class LifeBar : MonoBehaviour
    {
        [SerializeField] private Image _imagePrefab;
        
        private List<Image> _images = new();

        public void Init(int startCount)
        {
            ValidateCounter(startCount);
            
            _images.Clear();

            for (int i = 0; i < startCount; i++)
            {
                AddImage();
            }
        }

        public void SetValue(int value)
        {
            ValidateCounter(value);
            
            int delta = value - _images.Count;

            if (delta > 0)
                AddImages(delta);
            else if (delta < 0)
                RemoveImages(-delta);
        }

        private void AddImages(int count)
        {
            for (int i = 0; i < count; i++)
            {
                AddImage();
            }
        }

        private void RemoveImages(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Destroy(_images[^1].gameObject);
                _images.RemoveAt(_images.Count - 1);
            }
        }

        private void AddImage()
        {
            Image image = Instantiate(_imagePrefab, transform);
            _images.Add(image);
        }

        private void ValidateCounter(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than or equal to zero.");
        }
    }
}