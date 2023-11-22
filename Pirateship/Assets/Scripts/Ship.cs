using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth;
    private float _health;

    [SerializeField]
    private Image _healthBar;

    [SerializeField]
    private Sprite[] _spritesDamage;
    [SerializeField]
    private SpriteRenderer _spriteCurrent;

    [SerializeField]
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _health = _maxHealth;
       
    }

    // Update is called once per frame
    void Update()
    {
        MoveFoward();
        Rotate(30);
    }

    private void MoveFoward()
    {
        transform.position += -transform.up * Time.deltaTime * _speed;
    }

    private void Rotate(float rotation)
    {
        transform.Rotate(new Vector3(0,0, rotation) * Time.deltaTime);
    }

    private void ChangeHealth(float change)
    {
        _health += change;
    }

    private void TestHealth()
    {
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        else if(_health < 0) 
        {
            _health = 0;
        }
    }

    private void TestToDeath()
    {
        if(_health <= 0)
        {
            Debug.Log("die");
        }
    }

    private void ChangeHealthBar()
    {
        _healthBar.fillAmount = _health / _maxHealth;
    }

    private void ChangeSprite()
    {
        if(_health <= 0)
        {
            _spriteCurrent.sprite = _spritesDamage[0];
        }
        else if(_health < _maxHealth / 3)
        {
            _spriteCurrent.sprite = _spritesDamage[1];
        }
        else if(_health < _maxHealth * 2 / 3)
        {
            _spriteCurrent.sprite = _spritesDamage[2];
        }
    }

    public void GetDamage(float damage)
    {
        ChangeHealth(-damage);

        TestHealth();

        ChangeHealthBar();

        TestToDeath();

        ChangeSprite();
    }

    private IEnumerator TestHealtBar()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            GetDamage(10f);
        }
    }

    public void GetHeal(float heal)
    {
        ChangeHealth(heal);

        TestHealth();

        ChangeHealthBar();

        ChangeSprite();

    }

}
