using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HealthBar;
    public float maxHealth = 100f;
    public ParticleSystem bleed;
    public RectTransform gameOverPanel;
    System.Random rnd = new System.Random();

    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // DEBUGGING

        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(5);
        }
    }

    public void GainHealth(float amount)
    {
        currentHealth += amount;
        HealthBar.value = currentHealth;
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
        
        int range = rnd.Next(0, damageSounds.Length);
        string soundToPlay = damageSounds[range];

        if (currentHealth > 0)
        {
            FindObjectOfType<AudioManager>().Play(soundToPlay);
            bleed.Play();
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("playerDeath");
            Time.timeScale = 0f;
            gameOverPanel.gameObject.SetActive(true);
        }

        currentHealth -= damage;
        HealthBar.value = currentHealth;
    }
}