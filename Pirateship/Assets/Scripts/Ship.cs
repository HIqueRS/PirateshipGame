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

    // Start is called before the first frame update
    void Start()
    {
        _health = _maxHealth;
        StartCoroutine(TestHealtBar());
    }

    // Update is called once per frame
    void Update()
    {
        
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

        ChangeSprite();

        TestToDeath();
    }

    private IEnumerator TestHealtBar()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            GetDamage(10f);
        }
    }

}
