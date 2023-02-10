(Polska wersja językowa/Polish version: https://github.com/TaktycznyBocianDev/UmbrellaCollector/blob/main/README_PL.md)

# Umbrella The Game

A small game based on collecting objects - raindrops - that are falling from above. The player controls an umbrella, which protects its holder from getting
wet.

One of the most important challenges in this project was time pressure - as the project took me 1h 29min 11sec from start to finish.




## Experience gained:

- Working with Unity under time pressure
- Game menu 
- "Best Score" mechanics
- refining the project according to the instructions of the "client"
## Features

- Local best score
- HP and points mechanics
- Moving
- UI
- Prefabs and their creation on stage
- Music and sounds in the game
## About the Game 

In its assumptions, it is very simple. The player controls the umbrella at the bottom of the screen by moving it left or right. By doing so, he catches drops that fall from above. 
The player has 5 hp points, shown as a bar. After losing, the screen displays the score for the round and the best local score.
## Best Score 

The mechanics of counting points and storing the highest score can be found in BestScoreSystem.cs.

```javascript
private void NewBest(int points)
    {
        if (!File.Exists(Application.dataPath + "\\bestScore.json"))
        {
            MakeNewJsonWithBestPoints(points);
            DisplayCurrentPointsOnEnd(points);
            DisplayBestPointsOnEnd(points);
            ShowNewBestPopout();
        }
        else
        {
            string bestJson = File.ReadAllText(Application.dataPath + "\\bestScore.json");
            BestScore currentBest = JsonUtility.FromJson<BestScore>(bestJson);
            int tmpBestScore = currentBest.bestScore;

            if (points > tmpBestScore)
            {
                MakeNewJsonWithBestPoints(points);
                DisplayCurrentPointsOnEnd(points);
                DisplayBestPointsOnEnd(points);
                ShowNewBestPopout();
            }
            else
            {
                DisplayCurrentPointsOnEnd(points);
                DisplayBestPointsOnEnd(tmpBestScore);
            }

        }
    }
```

The whole core of the mechanics is in this function - we can either create a completely new record the first time we play, or check if the points obtained are indeed the new best score. If yes, we overwrite the .json file. If not - we just display the result and the read best score.



## Rain Maker

Rain maker is a script designed to create new water drops on top of the scene. They are prefab - a pre-prepared object to be copied.
Coroutine is also used here, allowing to stagger the appearance of the drops - MakeWaterDrop() - over time.

```javascript
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
```
## Screenshots


![App Screenshot](https://github.com/TaktycznyBocianDev/UmbrellaCollector/blob/main/Screens/1.jpg?raw=true)
The beginning of the game

![App Screenshot](https://github.com/TaktycznyBocianDev/UmbrellaCollector/blob/main/Screens/2.jpg?raw=true)
Umbrella at work :)

![App Screenshot](https://github.com/TaktycznyBocianDev/UmbrellaCollector/blob/main/Screens/3.jpg?raw=true)
Showing new highest score


