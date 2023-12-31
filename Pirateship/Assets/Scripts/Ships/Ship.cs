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
    protected float _damage;
    
    [SerializeField]
    private float _fireRate;

    [SerializeField]
    private float _fireSpeed;

    [SerializeField]
    private float _speed;

    [SerializeField]
    protected float _anglePerSecond;

    [SerializeField]
    private Image _healthBar;

    [SerializeField]
    protected Sprite[] _spritesDamage;
    [SerializeField]
    protected SpriteRenderer _spriteCurrent;


    [SerializeField]
    private GameObject _bullet;

    [SerializeField]
    private Animator _animator;


    private float _fowardCooldown;
    private float _sideCooldown;

    protected bool _isDead;

    protected bool _stop;

    [SerializeField]
    private GameObject[] _drops;

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
    protected virtual void Start()
    {
        _health = _maxHealth;
        _fowardCooldown = 0;
        _sideCooldown = 0;
        _isDead = false;
        _stop = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void PassCooldown()
    {
        _fowardCooldown += Time.deltaTime;
        _sideCooldown += Time.deltaTime;    
    }

    private void Shoot(Vector3 initialPosition, Vector3 direction)//add damage too
    {
        GameObject aux;

        Vector3 position;

        position = initialPosition + transform.position;

        position = new Vector3(position.x, position.y, -1);


        aux = GameObject.Instantiate(_bullet, position, Quaternion.identity);

        aux.GetComponent<Bullet>().InitiateBullet(direction, _fireSpeed + _speed, _damage);
    }

    protected void ShootFoward()
    {
        if(_fowardCooldown > 1/_fireRate)
        {
            Shoot((-transform.up * 0.8f), -transform.up);
            _fowardCooldown = 0;
        }
        
    }

    protected void ShootSideways()
    {
        if(_sideCooldown > 1/_fireRate)
        {
            Shoot((-transform.right * 0.6f) + ( transform.up * 0.3f), -transform.right);
            Shoot((-transform.right * 0.6f),                          -transform.right);
            Shoot((-transform.right * 0.6f) + (-transform.up * 0.3f), -transform.right);

            Shoot((transform.right * 0.6f) +  ( transform.up * 0.3f),  transform.right);
            Shoot((transform.right * 0.6f),                            transform.right);
            Shoot((transform.right * 0.6f) +  (-transform.up * 0.3f),  transform.right);

            _sideCooldown = 0; 
        }
        
    }

    private void Drop()
    {
        if(GameManager.Instance._config._hasDrop)
        {
            if (_drops.Length > 0)
            {
                int i;
                i = Random.Range(0, _drops.Length);

                GameObject.Instantiate(_drops[i], transform.position, Quaternion.identity);
            }
        }
    }

    protected void MoveFoward()
    {
        transform.position += -transform.up * Time.deltaTime * _speed;
    }

    protected void Rotate(float rotation)
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
            if(!_isDead)
            {
                StartCoroutine(Die());
            }
        }
    }

    protected IEnumerator Die()
    {
        CallDieEvent();

        _isDead = true;

        _animator.SetTrigger("Explode");

        Destroy(this.transform.parent.GetChild(1).gameObject);

        yield return new WaitForSeconds(2f);

        Drop();

        Destroy(this.transform.parent.gameObject);
    }

    protected virtual void CallDieEvent()
    {
        //implementation on enemyship and playership
    }

    private void ChangeHealthBar()
    {
        if(_isDead == false)
        {
            _healthBar.fillAmount = _health / _maxHealth;
        }
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

    public void GetHeal(float heal)
    {
        ChangeHealth(heal);

        TestHealth();

        ChangeHealthBar();

        ChangeSprite();

    }

    public void AddDamage(float damage)
    {
        _damage += damage;
    }

    public void AddFireRate(float firerate)
    {
        _fireRate += firerate;
    }

    public void AddFireSpeed(float speed)
    {
        _fireSpeed += speed;
    }

    public void AddSpeed(float speed)
    {
        _speed += speed;
    }

}
