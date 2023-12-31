using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    [SerializeField]
    private Vector3 _distance;

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _offset;

    private Vector3 _direction;

    [SerializeField]
    private float _speed;

    private float _currentDistance;

    private Vector3 _targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (_target != null)
        {
            _targetPosition = _target.position + _distance;

            _currentDistance = Vector2.Distance(_targetPosition, transform.position);
            if (_currentDistance > _offset)
            {
                
                
                _direction = _targetPosition - transform.position;
                _direction.Normalize();

                if(_currentDistance > 0.1)
                {
                    transform.position += _speed * Time.deltaTime * _direction;
                }
                

                
            }
        }
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void SetDistance(Vector3 dist)
    {
        _distance = dist;
    }

    public void SetOffSet(float offSet)
    {
        _offset = offSet;
    }
}