using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BallMotor))]
public class Player : MonoBehaviour
{
    [SerializeField] Text ScoreText;
    [SerializeField] Text HealthText;
    [SerializeField] Text SpeedText;
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
        ScoreText.text = "Points: " + _currentPoint.ToString();
        HealthText.text = "Health: " + _currentHealth.ToString() + "/" + _maxHealth.ToString();
        SpeedText.text = "Speed: " + _ballMotor.MaxSpeed.ToString();
    }
    private void FixedUpdate()
    {
        ProcessMovement();  
    }

    private void ProcessMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        _ballMotor.Move(movement);
    }

    public void CheckSpeed(float amount)
    {
        //displays and updates current player speed
        SpeedText.text = "Speed: " + _ballMotor.MaxSpeed.ToString();
    }
    public void IncreasePoint(int amount)
    {
        _currentPoint += amount;
        ScoreText.text = "Points: " + _currentPoint.ToString();
        Debug.Log(_currentHealth);
    }
    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        HealthText.text = "Health: " + _currentHealth.ToString() + "/" + _maxHealth.ToString();
        Debug.Log(_currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        //check if player is Invincible to decide rather player take damage or not.
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
        HealthText.text = "Health: " + _currentHealth.ToString() + "/" + _maxHealth.ToString();
        if (_currentHealth <= 0)
        {
            Kill();
        }
        Debug.Log(_currentHealth);
    }

    public void Kill()
    {
        //checks if player is Invincible to decide rather player gets killed or not.
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
