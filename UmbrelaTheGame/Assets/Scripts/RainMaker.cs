using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainMaker : MonoBehaviour
{
    [Header("Water Drop Prefab")]
    [SerializeField] GameObject prefab;

    [Header("How long wait for the new water drop?")]
    [SerializeField] float waitTime;

    [Header("How far to left and right will water spawn?")]
    [SerializeField] float waterRange;


    public void StartTheRain() => StartCoroutine(MakeWaterDrop());


    IEnumerator MakeWaterDrop()
    {

        while (true)
        {
            Instantiate(prefab, SetWaterPos(), Quaternion.identity) ;
            yield return new WaitForSeconds(waitTime);

        }

    }

    private Vector3 SetWaterPos()
    {
        return new Vector3(Random.Range(-waterRange, waterRange), transform.position.y, transform.position.z);
    }
}
