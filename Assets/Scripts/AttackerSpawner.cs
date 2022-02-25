using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    private bool spawn = true;
    [SerializeField] private int minSpawnDelay;
    [SerializeField] private int maxSpawnDelay;
    [SerializeField] private Attacker[] attackersPrefab;

    private IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        var index = Random.Range(0, attackersPrefab.Length);
        Spawn(attackersPrefab[index]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation);
        newAttacker.transform.parent = transform;
    }

    public void StopSpawn()
    {
        spawn = false;
    }
}
