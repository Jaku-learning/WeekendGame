using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    public float projectileSpeed;
    public float lifetime;

    private void Start()
    {
        Invoke("DestroyProjectile", lifetime);
    }
    
    private void Update()
    {
        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
        PlayParticle();
    }

    private void PlayParticle()
    {
        particleSystem.Play();
    }
}
