using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxhealth = 100f;
    private float currenthealth;
    public Slider healthbar; // Make sure to assign this in the Inspector
    public GameObject gameoverscreen; // Assign a Game Over UI Panel

    void Start()
    {
        currenthealth = maxhealth;
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthbar != null)
        {
            healthbar.value = currenthealth / maxhealth; // Use value instead of fillAmount
        }
    }

    void Die()
    {
        Debug.Log("Player Died!!");
        gameoverscreen.SetActive(true); // Show Game Over screen
        Time.timeScale = 0; // Pause the game
    }

    public void takedamage(float amount)
    {
        currenthealth -= amount;
        UpdateHealthUI();

        if (currenthealth <= 0f)
        {
            Die();
        }
    }
}
