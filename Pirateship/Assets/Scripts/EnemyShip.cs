using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyShip : Ship
{

    [SerializeField]
    protected Transform _target;

    private Vector2 _targetDir;

    private float _angleToTarget;

    public static event Action<int> EnemyDie;

    [SerializeField]
    private int _points;

    //drop depois kk

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }


    public void RotateTowardsTarget()
    {
        if (_target != null) 
        {
            _targetDir = _target.position - transform.position;

            _targetDir.Normalize();

            _angleToTarget = Vector2.SignedAngle(-transform.up, _targetDir);

            if(_angleToTarget > 0)
            {
                Rotate(_anglePerSecond);
            }
            else if(_angleToTarget < 0)
            {
                Rotate(-_anglePerSecond);
            }
        }
    }

    protected override void CallDieEvent()
    {
        EnemyDie?.Invoke(_points);
    }

    protected void ChangeSprite()
    {
        _spriteCurrent.sprite = _spritesDamage[0];
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isDead == false)
        {
            if (collision != null)
            {
                if (collision.gameObject.GetComponent<Ship>() != null)
                {
                    collision.gameObject.GetComponent<Ship>().GetDamage(_damage);

                }
                else if(collision.gameObject.CompareTag("Isle"))
                {
                    ChangeSprite();

                    StartCoroutine(Die());
                }
            }
        }
    }
}
