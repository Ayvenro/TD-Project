using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject winLabel;
    [SerializeField] private GameObject loseLabel;
    private int attackersAlive;
    private bool isLevelFinished;
    private int waitForLoad = 4;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }
    public void AttackerSpawned()
    {
        attackersAlive++;
    }

    public void AttackerKilled()
    {
        attackersAlive--;
        if (isLevelFinished && attackersAlive <= 0)
        {
            StartCoroutine(HandleWinCondition());
            Debug.Log("End level");
        }
    }

    public void LevelFinished()
    {
        isLevelFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (var spawn in attackerSpawners)
        {
            spawn.StopSpawn();
        }
    }

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitForLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }
}
