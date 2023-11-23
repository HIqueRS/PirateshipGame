using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{

    [SerializeField]
    public GameObject _target;

    private Vector2 _targetDir;

    private float _angleToTarget;

    //drop depois kk

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RotateTowardsTarget()
    {
        if (_target != null) 
        {
            _targetDir = _target.transform.position - transform.position;

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
}
