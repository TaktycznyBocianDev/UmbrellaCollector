using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllWaterDrops : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] drops = GameObject.FindGameObjectsWithTag("Water");
        if (!(drops.Length == 0))
        {
            for (int i = 0; i < drops.Length; i++)
            {
                Destroy(drops[i]);
            }
        }
    }
}
