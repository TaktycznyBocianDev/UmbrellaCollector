using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadZoneCollision : MonoBehaviour
{
    [Header("How much chanses do we need?")]
    public int health;

    [Header("Health Bar of this game")]
    [SerializeField] GameObject healthBarObj;

    [SerializeField] AudioSource rainHitGround;

    private HealtBar healthBar;

    private void Start()
    {
        healthBar = healthBarObj.GetComponent<HealtBar>();
        healthBar.SetMaxValue(health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            Destroy(collision.gameObject);
            health -= 1;
            rainHitGround.Play();
            healthBar.SetHealth(health);
            
        }
    }
}
