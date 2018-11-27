using UnityEngine;

public class BluePickup : MonoBehaviour
{
    private GameObject player;
    public ParticleSystem pickupParticle;

    // Use this for initialization
    void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player"); // find player
    }
	
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            PlayerHealth playerHealthies = player.GetComponent<PlayerHealth>();
            if (playerHealthies != null)
            {
                if (playerHealthies.currentHealth >= 100f)
                {
                    return;
                }
                if (playerHealthies.currentHealth <= 90f)
                {
                    FindObjectOfType<AudioManager>().Play("pickupHealth");
                    pickupParticle.Play();
                    playerHealthies.GainHealth(10);
                    Destroy(gameObject, 1.5f);
                }
            }
        }
    }
}
