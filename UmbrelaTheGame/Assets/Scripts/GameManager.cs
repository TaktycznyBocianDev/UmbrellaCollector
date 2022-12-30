using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Our Star")]
    [SerializeField] GameObject player;

    [Header("Game Starts")]
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject rainGenerator;
    private RainMaker rainMaker;
    

    [Header("Late end game")]
    [SerializeField] GameObject deadZone;
    [SerializeField] GameObject endScreen;
    private DeadZoneCollision dead;


    private void Start()
    {
        rainMaker = rainGenerator.GetComponent<RainMaker>();
        dead = deadZone.GetComponent<DeadZoneCollision>();

        startScreen.SetActive(true);
    }

    private void Update()
    {
        if (dead.health == 0)
        {
            player.GetComponent<Movement>().enabled = false;
            rainMaker.StopAllCoroutines();
            endScreen.SetActive(true);

        }
    }

    public void GameStarts()
    {
        startScreen.SetActive(false);
        rainMaker.StartTheRain();
        
    }

}
