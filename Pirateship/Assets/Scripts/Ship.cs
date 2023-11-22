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

    [SerializeField]
    private GameObject _bullet;

    // Start is called before the first frame update
    void Start()
    {
        _health = _maxHealth;

        StartCoroutine(TestHealtBar());
    }

    // Update is called once per frame
    void Update()
    {
        MoveFoward();
        Rotate(30);
    }

    private void Shoot(Vector3 initialPosition,float force, Vector3 direction)
    {
        GameObject aux;

        aux = GameObject.Instantiate(_bullet, initialPosition + transform.position, Quaternion.identity);

        aux.GetComponent<Bullet>().InitiateBullet(direction, force);
    }

    private void ShootFoward()
    {
        Shoot((-transform.up * 0.8f), 5, -transform.up);
    }

    private void ShootSideways()
    {

        Shoot((-transform.right * 0.6f) + ( transform.up * 0.3f), 5, -transform.right);
        Shoot((-transform.right * 0.6f)                         , 5, -transform.right);
        Shoot((-transform.right * 0.6f) + (-transform.up * 0.3f), 5, -transform.right);

        Shoot((transform.right * 0.6f)  + ( transform.up * 0.3f), 5, transform.right);
        Shoot((transform.right * 0.6f)                          , 5, transform.right);
        Shoot((transform.right * 0.6f)  + (-transform.up * 0.3f), 5, transform.right);
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
        else
        {
            _spriteCurrent.sprite = _spritesDamage[3];
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

            GetDamage(35f);
            ShootSideways();
            ShootFoward();

            yield return new WaitForSeconds(1f);

            GetDamage(33f);
            ShootSideways();
            ShootFoward();

            yield return new WaitForSeconds(1f);

            GetDamage(32f);
            ShootSideways();
            ShootFoward();

            yield return new WaitForSeconds(1f);

            GetHeal(33f);
            ShootSideways();
            ShootFoward();

            yield return new WaitForSeconds(1f);

            GetHeal(33f);
            ShootSideways();
            ShootFoward();

            yield return new WaitForSeconds(1f);

            GetHeal(34f);
            ShootSideways();
            ShootFoward();
           

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
