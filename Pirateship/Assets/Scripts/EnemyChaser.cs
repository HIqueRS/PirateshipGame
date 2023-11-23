using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : EnemyShip
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (_isDead == false)
        {
            if (_target != null)
            {
                RotateTowardsTarget();
                MoveFoward();
            }
        }
    }

    private void ChangeSprite()
    {
        _spriteCurrent.sprite = _spritesDamage[0];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if(collision.gameObject.GetComponent<Ship>() != null)
            {
                collision.gameObject.GetComponent<Ship>().GetDamage(_damage);

                ChangeSprite();

                StartCoroutine(Die());
            }
            
        }
    }
}
