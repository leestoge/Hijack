using UnityEngine;

public class targetPhish : MonoBehaviour
{
    public float health = 50f;
    public ParticleSystem deathParticles;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health < 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // play particle?
        deathParticles.Play();
        Destroy(gameObject, 1f);
    }
}
