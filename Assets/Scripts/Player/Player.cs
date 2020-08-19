using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BallMotor))]
public class Player : MonoBehaviour
{
    [SerializeField] Text ScoreText;
    [SerializeField] int _maxHealth = 3;
    int _currentHealth;
    int _currentPoint;
    [SerializeField] bool isInvincible = false;

    BallMotor _ballMotor;

    private void Awake()
    {
        _ballMotor = GetComponent<BallMotor>();
        
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        _currentPoint = _currentPoint;
    }
    private void FixedUpdate()
    {
        ProcessMovement();  
    }

    private void Update()
    {
        ScoreText.text = "Points: " + _currentPoint.ToString();
    }
    private void ProcessMovement()
    {
        //TODO move into Input script
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        _ballMotor.Move(movement);
    }

    public void IncreasePoint(int amount)
    {
        _currentPoint += amount;
        
    }
    public void IncreaseHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log(_currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
       int BaseAmount = amount;
        if(isInvincible == true)
        {
            amount = 0;
        }
        else
        {
            amount = BaseAmount;
        }
        _currentHealth -= amount;

        if(_currentHealth <= 0)
        {
            Kill();
        }
        Debug.Log(_currentHealth);
    }

    public void Kill()
    {
        if(isInvincible == true)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void SetInvincibilityStatus(bool Status)
    {
        isInvincible = Status;
    }
}
