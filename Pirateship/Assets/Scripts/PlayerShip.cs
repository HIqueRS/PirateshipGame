using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShip : Ship
{
    [SerializeField]
    private InputSchema _input;

    public static event Action PlayerDie;



    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(_stop == false)
        {

            if(_isDead == false)
            {
                Inputs();
                PassCooldown();
            }
        }
    }
       


    private void Inputs()
    {
        if(_input.FowardPressed())
        {
            MoveFoward();
        }

        if(_input.LeftPressed())
        {
            Rotate(_anglePerSecond);
        }

        if (_input.RightPressed())
        {
            Rotate(-_anglePerSecond);
        }

        if(_input.FireFowardPressed())
        {
            ShootFoward();
        }

        if(_input.FireSidePressed())
        {
            ShootSideways();
        }
    }

    protected override void CallDieEvent()
    {
        PlayerDie?.Invoke();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isDead == false)
        {
            if (collision != null)
            {
                
                if (collision.gameObject.CompareTag("Isle"))
                {

                    GetDamage(30);
                    
                }
            }
        }
    }

}
