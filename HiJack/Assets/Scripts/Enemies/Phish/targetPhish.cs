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
        deathParticles.Play(); // play particle
        Destroy(gameObject, 1f); // delay destroy by 1 second
    }
}
