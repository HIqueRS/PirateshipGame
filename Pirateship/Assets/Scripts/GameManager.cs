using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int _points;

    public static event Action GameEnds;

    private bool _hasEnded;

    private int _finalPoints;

    public static GameManager Instance;

    [SerializeField]
    private float _time;
    private float _currentTime;

    private void OnEnable()
    {

        Instance = this;

        EnemyShip.EnemyDie += SumPoints;
        PlayerShip.PlayerDie += EndGame;
    }
    private void OnDisable()
    {
        EnemyShip.EnemyDie -= SumPoints;
        PlayerShip.PlayerDie -= EndGame;
        
    }

    private void SumPoints(int i)
    {
        _points += i;
    }

    public int GetPoints()
    {
        return _finalPoints;
    }


    private void EndGame()
    {
        _hasEnded = true;
        _finalPoints = _points;
        GameEnds?.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        _points = 0;
        _hasEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime > _time)
        {
            if(_hasEnded == false)
            {
                EndGame();
            }
        }

    }
}
