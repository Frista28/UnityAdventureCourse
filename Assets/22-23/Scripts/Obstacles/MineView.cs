using _22_23.Scripts.Obstacles;
using UnityEngine;

public class MineView : MonoBehaviour
{
    [SerializeField] private ExplosionEffect _explosionEffectPrefab;

    public void Explode()
    {
        Instantiate(_explosionEffectPrefab, transform.position, Quaternion.identity);
    }
}
