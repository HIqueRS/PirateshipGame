using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class DropScript : MonoBehaviour
{

    private Ship _ship;

    [SerializeField]
    private float _heal;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _fireRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.CompareTag("Player"))
        {
            
            _ship = collision.gameObject.GetComponent<Ship>();

            _ship.AddDamage(_damage);
            _ship.AddFireRate(_fireRate);
            _ship.GetHeal(_heal);

            Destroy(this.gameObject);
        }
        
    }
}
