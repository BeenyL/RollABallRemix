using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : CollectibleBase
{
    [SerializeField] float _speedAmount = 3;

    protected override void Collect(Player player)
    {
        BallMotor _motor = player.GetComponent<BallMotor>();
        if(_motor != null)
        {
            _motor.MaxSpeed += _speedAmount;
        }
        player.CheckSpeed(_speedAmount);
    }

    protected override void Movement(Rigidbody rb)
    {
        Quaternion turnOffset = Quaternion.Euler
            (MovementSpeed, MovementSpeed, MovementSpeed);
        rb.MoveRotation(rb.rotation * turnOffset);
    }

}
