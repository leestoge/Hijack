using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Phish : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent enemy;
    private BoxCollider hitBox;

    public float health = 50f;
    public ParticleSystem deathParticles;
    public GameObject bluePickup;
    readonly System.Random rnd = new System.Random();
    

    // Use this for initialization
    void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player"); // find player
	    enemy = GetComponent<NavMeshAgent>(); // get navmesh component from the game object
	    hitBox = GetComponent<BoxCollider>();// get box collider component from the game object
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
        hitBox.enabled = false;
        enemy.Stop();
        DropPickup();
        deathParticles.Play(); // play particle
        Destroy(gameObject, 0.5f); // delay destroy by half a second
        FindObjectOfType<PlayerPoints>().AwardPhishKill();
    }

    void DropPickup()
    {        
        int dropChance = rnd.Next(1, 3);
        if (dropChance != 1) // if "drop chance" is not equal to 1 then proceed
        {
            var drop = Instantiate(bluePickup, transform.localPosition + (transform.transform.up * 1), Quaternion.identity);
            Destroy(drop, 60);
        }
    }
}
