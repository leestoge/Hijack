using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private GameObject _player;
    private bool _collidedWithPlayer;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            print("enter trigger with _player");
           Attack();
            print("attempting to do damage");
        }    
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            print("exit trigger with _player");
            _collidedWithPlayer = false;
        }      
    }

    private void Attack()
    {
        PlayerHealth playerDamage = _player.GetComponent<PlayerHealth>();
        if (playerDamage != null)
        {
            playerDamage.TakeDamage(10f);
        }
    }
}