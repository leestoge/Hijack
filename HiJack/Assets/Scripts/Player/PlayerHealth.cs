using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HealthBar;
    public float maxHealth = 100f;

    private float _currentHealth;

    void Start()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        var damageSounds = new[]
        {
            "Damage1",
            "Damage2",
            "Damage3",
            "Damage4"
        }; // array of strings that holds the damage sound names
        System.Random rnd = new System.Random();
        int range = rnd.Next(0, damageSounds.Length);
        string soundToPlay = damageSounds[range];

        FindObjectOfType<AudioManager>().Play(soundToPlay);

        _currentHealth -= damage;
        HealthBar.value = _currentHealth;
    }
}