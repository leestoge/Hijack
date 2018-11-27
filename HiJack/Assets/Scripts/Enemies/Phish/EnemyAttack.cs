using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
           Attack();
        }
    }

    private void Attack()
    {
        PlayerHealth playerDamage = player.GetComponent<PlayerHealth>();
        if (playerDamage != null)
        {
            playerDamage.TakeDamage(5f); // set to 10 again, should work better with the reduced hit range.
        }
    }
}