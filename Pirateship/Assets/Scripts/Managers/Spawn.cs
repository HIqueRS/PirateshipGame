using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerShip;
    [SerializeField]
    private GameObject[] _enemies;

    
    private float _secToSpawn;
    private float _timePassed;

    [SerializeField]
    private float _radiusToSpawn;
    
    private Vector3 _enemyPosition;

    [SerializeField]
    private Camera _camera;

    public static event Action<Transform> SpawnPlayer;

    protected bool _stop;

    public GameConfig _config;

    private void OnEnable()
    {
        GameManager.GameEnds += Stop;
    }

    private void OnDisable()
    {
        GameManager.GameEnds -= Stop;

    }

    private void Stop()
    {
        _stop = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializePlayer();


        _timePassed = 0;

        _secToSpawn = _config._secondsToSpawn;

        TestAndSpawn();

    }

    // Update is called once per frame
    void Update()
    {
        if( _playerShip != null )
        {
            if(_stop == false)
            {
                SpawningEnemies();
            }
        }
    }

    private void InitializePlayer()
    {
        _playerShip = GameObject.Instantiate(_playerShip,transform.position,Quaternion.identity);

        _playerShip = _playerShip.transform.GetChild(0).gameObject;

        SpawnPlayer?.Invoke(_playerShip.transform);
    }


    private void SpawningEnemies()
    {
        _timePassed += Time.deltaTime;

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

        r2 = UnityEngine.Random.Range(0, _enemies.Length);

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

        pos = UnityEngine.Random.insideUnitCircle.normalized * _radiusToSpawn;

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


                    

                