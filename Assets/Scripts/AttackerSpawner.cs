using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    private bool spawn = true;
    [SerializeField] private int minSpawnDelay;
    [SerializeField] private int maxSpawnDelay;
    [SerializeField] private Attacker attackerPrefab;
    // Start is called before the first frame update
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
        Instantiate(attackerPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
