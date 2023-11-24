using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _direction;
    private float _velocity;

    private float _damage;

    private Vector2 _initialPosition;

    private float _range; //maybe change to the player control this variable

    private bool _isMoving;

    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        _range = 10f;
        _isMoving = true;

        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_isMoving)
        {
            if (Vector2.Distance(transform.position, _initialPosition) < _range)
            {
                GoingFoward();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
    }

    private void GoingFoward()
    {
        transform.position += _velocity * Time.deltaTime * _direction;

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
        if(_isMoving)
        {
            if(collision != null)
            {
                collision.gameObject.GetComponent<Ship>().GetDamage(_damage);

                _isMoving = false;
                //play animation
                _anim.SetTrigger("Explode");

               

                Destroy(this.gameObject,0.5f);
            
            }
        }
    }
}
