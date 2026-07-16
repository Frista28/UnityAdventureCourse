using _20_21.Scripts;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private const KeyCode moveLeft = KeyCode.A;
    private const KeyCode moveRight = KeyCode.D;
    private const KeyCode sailLeft = KeyCode.Q;
    private const KeyCode sailRight = KeyCode.E;
    
    [SerializeField] private Wind _wind;
    
    [SerializeField] private float _rotationSpeed = 5;
    
    [SerializeField] private GameObject _sail;
    
    private Vector3 _bodyRotation;
    private Vector3 _sailRotation;
    
    // public Vector3 BodyRotation => _bodyRotation;
    // public Vector3 SailRotation => _sailRotation;

    private void Awake()
    {
        _bodyRotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        ShipRotate();

        SailRotate();
        
        Move();
    }
    
    private void ShipRotate()
    {
        float angleDirection = GetAxis(moveLeft, moveRight);
        
        float newAngle = _bodyRotation.y + angleDirection * _rotationSpeed * Time.deltaTime;
        
        _bodyRotation.y = newAngle;
        
        transform.rotation = Quaternion.Euler(_bodyRotation);
    }

    private void SailRotate()
    {
        float angleDirection = GetAxis(sailLeft, sailRight);
        
        float newAngle = _sailRotation.y + angleDirection * _rotationSpeed * Time.deltaTime;
        
        _sailRotation.y = Mathf.Clamp(newAngle, -90f, 90f);
        
        _sail.transform.localRotation = Quaternion.Euler(_sailRotation);
    }
    
    private float GetAxis(KeyCode negative, KeyCode positive)
    {
        float value = 0f;
        if (Input.GetKey(negative)) value -= 1f;
        if (Input.GetKey(positive)) value += 1f;
        return value;
    }

    private void Move()
    {
        float dotProduct = Vector3.Dot(_wind.Direction, _sail.transform.forward) * Vector3.Dot(_sail.transform.forward, transform.forward);
        
        if (dotProduct <= 0f)
            return;
        
        transform.position += transform.forward * dotProduct * _wind.Speed * Time.deltaTime;
    }
}
