using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    [SerializeField]
    private InputSchema _input;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        PassCooldown();
    }

    private void Inputs()
    {
        if(_input.FowardPressed())
        {
            MoveFoward();
        }

        if(_input.LeftPressed())
        {
            Rotate(30);
        }

        if (_input.RightPressed())
        {
            Rotate(-30);
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
