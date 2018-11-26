using UnityEngine;
using UnityEngine.AI;

public class Phish : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent enemy;

    public float health = 50f;
    public ParticleSystem deathParticles;

    // Use this for initialization
    void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player"); // find player
	    enemy = GetComponent<NavMeshAgent>(); // initialise nav mesh
	}
	
	// Update is called once per frame
	void Update ()
	{
	    enemy.destination = player.transform.position; // find player
	}

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
        enemy.Stop();
        deathParticles.Play(); // play particle
        Destroy(gameObject, 0.5f); // delay destroy by 1 second
    }
}
