using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : EnemyShip
{
   

    // Update is called once per frame
    void Update()
    {

        if (_stop == false)
        {
            if (_isDead == false)
            {
                PassCooldown();

                RotateTowardsTarget();
                if(_target != null)
                {
                    if(Vector2.Distance(transform.position,_target.transform.position) < 5)
                    {
                        ShootFoward();
                    }
                    else
                    {
                        MoveFoward();
                    }
                }
            }

        }

    }
}
