using UnityEngine;
using UnityEngine.UI;

public class CollisionPlayerWater : MonoBehaviour
{
    [Header("Where we will show points?")]
    [SerializeField] Text text;

    [Header("Audio sorce for water hits player")]
    [SerializeField] AudioSource PointSound;

    //Points in our game. They should be modified only there, but could be get from there to other scripts.
    private int points;
    public int GetPoints() { return points; }

    private void Start()
    {
        points = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            Destroy(collision.gameObject);
            points += 1;
            PointSound.Play();
            text.text = "Points: " + points.ToString();
        }
    }
}
