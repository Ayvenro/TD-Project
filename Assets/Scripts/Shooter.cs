using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public void Fire(GameObject projectilePrefab)
    {
        Instantiate(projectilePrefab, transform.GetChild(0).position, transform.rotation);
    }
}
