using UnityEngine;
using UnityEngine.UI;



public class CollisionPlayerWater : MonoBehaviour
{
    [Header("Where we will show points?")]
    [SerializeField] Text text;

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
            text.text = "Points: " + points.ToString();
        }
    }
}
