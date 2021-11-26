using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ParticleSystem))]
public class FallingDamgeObject : MonoBehaviour
{
    [SerializeField] private int damage = 5;

    private ParticleSystem particle = null; // TODO : 적용

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

        switch(damageable == null)
        {
            case true:
                Disable();
                break;

            case false:
                damageable.OnDamage(damage);
                Disable();
                break;
        }
    }

    private void Disable()
    {
        // particle.Play();
        gameObject.SetActive(false);
    }
}
