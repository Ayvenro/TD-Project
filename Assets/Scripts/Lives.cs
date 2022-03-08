using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Lives : MonoBehaviour
{
    private int lives = 100;
    private TextMeshProUGUI liveText;

    private void Start()
    {
        lives -= PlayerPrefsController.GetDifficulty() * 10;
        liveText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
        Debug.Log("Current lives: " + lives);
    }

    private void UpdateDisplay()
    {
        liveText.text = lives.ToString();
    }

    public void DecreaseLive(int amount)
    {
        if (lives >= amount)
        {
            lives -= amount;
            UpdateDisplay();
            if (lives <= amount)
            {
                FindObjectOfType<LevelController>().HandleLoseCondition();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<Attacker>())
        {
            DecreaseLive(1);
        }
    }
}
