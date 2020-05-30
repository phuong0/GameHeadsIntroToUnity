using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public Slider healthBarUI;

    public Transform spawnPoint;
    public GameObject gameUI;
    public GameObject gameOver;

    private float currentHealth = 1.0f;

    public void HitObstacle(float damage)
    {
        currentHealth -= damage;
        UpdateHealth();

        if (currentHealth <= 0.0f)
        {
            gameUI.SetActive(false);
            gameOver.SetActive(true);
        }
    }

    private void UpdateHealth()
    {
        healthBarUI.value = currentHealth;
    }

    public bool isGameOver()
    {
        return (currentHealth <= 0.0f);
    }

    public void Respawn()
    {
        currentHealth = 1.0f;

        UpdateHealth();

        gameObject.transform.position = spawnPoint.position;
    }
}