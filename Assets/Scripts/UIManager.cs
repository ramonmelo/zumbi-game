using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;

    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerController.OnHealthChanged += PlayerController_OnHealthChanged;
        healthBar.value = healthBar.maxValue = playerController.PlayerHealth;
    }

    private void PlayerController_OnHealthChanged(int playerHealth)
    {
        healthBar.value = playerHealth;

        if (playerHealth <= 0)
        {
            GameManager.instance.RaiseGameOver();
        }
    }

    public void RestartGameHandler()
    {
        GameManager.instance.RaiseRestart();
    }
}
