using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerShip;
    [SerializeField]
    private GameObject[] _enemies;

    [SerializeField]
    private float _secToSpawn;
    private float _timePassed;

    [SerializeField]
    private float _radiusToSpawn;
    
    private Vector3 _enemyPosition;
    // Start is called before the first frame update
    void Start()
    {
        InitializePlayer();
       
        _timePassed = 0;

        TestAndSpawn();

    }

    // Update is called once per frame
    void Update()
    {
        if( _playerShip != null )
        {
            SpawningEnemies();
        }
    }

    private void InitializePlayer()
    {
        _playerShip = GameObject.Instantiate(_playerShip,transform.position,Quaternion.identity);

        _playerShip = _playerShip.transform.GetChild(0).gameObject;
    }

    private void SpawningEnemies()
    {
        _timePassed += Time.deltaTime;//tirar a passagem de tempo dessa função?

        if( _timePassed > _secToSpawn )
        {

            TestAndSpawn();

            _timePassed = 0;
        }
    }

    private void TestAndSpawn()
    {
        int r2;

        _enemyPosition = RandPosition();
        while (IsColiding(_enemyPosition))
        {
            _enemyPosition = RandPosition();
        }

        r2 = Random.Range(0, _enemies.Length);

        SpawnEnemy(r2, _enemyPosition);
    }

    private bool IsColiding(Vector3 pos)
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(pos, Vector2.up,1);
       
        return hit;
    }

    private Vector3 RandPosition()
    {
        Vector3 pos;

        pos = Random.insideUnitCircle.normalized * _radiusToSpawn;

        pos += _playerShip.transform.position;

        return pos;
    }

    private void SpawnEnemy(int n, Vector3 position)
    {
        GameObject enemy;

        enemy = Instantiate(_enemies[n], position, Quaternion.identity);

        enemy.transform.GetComponentInChildren<EnemyShip>().SetTarget(_playerShip.transform);
    }
}


                    

                