using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncrease : CollectibleBase
{
    [SerializeField] int _healthAdded = 1;

    protected override void Collect(Player player)
    {
        player.IncreaseHealth(_healthAdded);
    }
    protected override void Movement(Rigidbody rb)
    {
        Quaternion turnOffset = Quaternion.Euler
            (-MovementSpeed, -MovementSpeed, -MovementSpeed);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
