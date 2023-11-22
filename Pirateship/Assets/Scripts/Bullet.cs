using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _direction;
    private float _velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _direction * Time.deltaTime * _velocity;
    }


    private void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void SetVelocity(float velocity)
    {
        _velocity = velocity;
    }

    public void InitiateBullet(Vector3 direction, float velocity)
    {
        SetDirection(direction);
        SetVelocity(velocity);
    }
}
