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
        //-MovementSpeed to change the direction to the opposite direction for variety within the collectible.
        Quaternion turnOffset = Quaternion.Euler
            (-MovementSpeed, -MovementSpeed, -MovementSpeed);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
