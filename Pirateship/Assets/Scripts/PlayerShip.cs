using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    [SerializeField]
    private InputSchema _input;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if(_isDead == false)
        {
            Inputs();
            PassCooldown();
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

}
