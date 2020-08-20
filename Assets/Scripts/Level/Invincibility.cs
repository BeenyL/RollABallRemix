using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
    //colors of the ball based on state
    [SerializeField] Color ChangedColor;
    [SerializeField] Color DefaultColor;

    protected override void PowerUp(Player player)
    {
        ChangeColor(player);
        InvincibilityStatus(player,true);
        StartCoroutine(PowerUpCoroutine(player));
    }

    IEnumerator PowerUpCoroutine(Player player)
    {
        yield return new WaitForSeconds(PDuration);

        PowerDown(player);
    }

    protected override void PowerDown(Player player)
    {
        RestoreColor(player);
        player.SetInvincibilityStatus(false);
        Debug.Log("end");
    }

    void InvincibilityStatus(Player player, bool Status)
    {
        player.SetInvincibilityStatus(Status);
    }


    void RestoreColor(Player player)
    {
        MeshRenderer meshrenderer = player.GetComponent<MeshRenderer>();
        //reverts the players back to the originals.
        meshrenderer.material.color = DefaultColor;
    }
    void ChangeColor(Player player)
    {
        MeshRenderer meshrenderer = player.GetComponent<MeshRenderer>();
        //changes players color.
        meshrenderer.material.color = ChangedColor;
    }

}
