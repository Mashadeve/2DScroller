using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;
    private float startHealth = 0f;
    public static UIManager instance;

    [SerializeField]

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        if (startHealth == 0)
            startHealth = maxHealth;
        StartCoroutine(SmoothBar(currentHealth, maxHealth));
    }

    private IEnumerator SmoothBar(float currentHealth, float maxHealth)
    {
        while (startHealth > currentHealth)
        {
            startHealth -= (startHealth - currentHealth) * 0.02f;
            healthBar.fillAmount = startHealth / maxHealth;
            if (startHealth <= currentHealth)
            {
                startHealth = currentHealth;
                break;
            }
            yield return null;
        }
    }


}
