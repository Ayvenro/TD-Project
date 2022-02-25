using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int attackersAlive;
    private bool isLevelFinished;

    public void AttackerSpawned()
    {
        attackersAlive++;
    }

    public void AttackerKilled()
    {
        attackersAlive--;
        if (isLevelFinished && attackersAlive <= 0)
        {
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
}
