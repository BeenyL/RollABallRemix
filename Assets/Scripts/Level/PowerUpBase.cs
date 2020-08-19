using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class PowerUpBase : MonoBehaviour
{
    protected abstract void PowerUp(Player player);
    protected abstract void PowerDown(Player player);
    [SerializeField] float powerupDuration;
    protected float PDuration { get { return powerupDuration; } }
    [SerializeField] ParticleSystem _powerParticles;
    [SerializeField] AudioClip _powerSound;
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            DisableSelf();
            PowerUp(player);
            Feedback();
            
        }
    }

    private void Feedback()
    {
        if (_powerParticles != null)
        {
            _powerParticles = Instantiate(_powerParticles, transform.position, Quaternion.identity);

        }

        if (_powerSound != null)
        {
            AudioHelper.PlayClip2D(_powerSound, 1f);
        }
    }
    protected void DisableSelf()
    {
       MeshRenderer meshrenderer = gameObject.GetComponent<MeshRenderer>();
       Collider collider = gameObject.GetComponent<Collider>();

        meshrenderer.enabled = false;
        collider.enabled = false;

    }
}

