using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _direction;
    private float _velocity;

    private float _damage;

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

    private void SetDamage(float damage)
    {
        _damage = damage;
    }

    public void InitiateBullet(Vector3 direction, float velocity, float damage)
    {
        SetDirection(direction);
        SetVelocity(velocity);
        SetDamage(damage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            collision.gameObject.GetComponent<Ship>().GetDamage(_damage);
        }
    }
}
