using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bouncer : Enemy
{
    [SerializeField] float PushForce = 100f;
    //override PlayerImpact adding knockback on top of damaging player.
    protected override void PlayerImpact(Player player)
    {
        player.DecreaseHealth(Damage);
        Knockback(player);
        Debug.Log("pushed");
    }
    void Knockback(Player player)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        Vector3 playerPosition = transform.position - player.transform.position;
        
        rb.AddForce(-playerPosition * PushForce);
    }
}

