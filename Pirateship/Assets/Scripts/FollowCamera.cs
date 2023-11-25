using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : Follow
{
    private void OnEnable()
    {
        Spawn.SpawnPlayer += SetTarget;
    }

    private void OnDisable()
    {
        Spawn.SpawnPlayer -= SetTarget;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame

}
