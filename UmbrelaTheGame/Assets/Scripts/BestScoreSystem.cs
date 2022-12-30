using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class BestScoreSystem : MonoBehaviour
{

    public GameObject Player;
    private CollisionPlayerWater collisionGivesPoints;

    private int points;

    public GameObject pointsTxt;

    public Text currentPointsTxt;
    private void DisplayCurrentPointsOnEnd(int points) { currentPointsTxt.text = "Twoje punkty to: " + points.ToString(); }
    public Text bestPointsTxt;
    private void DisplayBestPointsOnEnd(int points) { bestPointsTxt.text = "Najlepszy wynik to: " + points.ToString(); }
    public GameObject newBestPopoutTxt;
    private void ShowNewBestPopout() { newBestPopoutTxt.SetActive(true); }


    private void Awake()
    {
        collisionGivesPoints = Player.GetComponent<CollisionPlayerWater>();
        points = collisionGivesPoints.GetPoints();
        pointsTxt.SetActive(false);

        NewBest(points);
    }

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

    private void MakeNewJsonWithBestPoints(int points)
    {
        BestScore bestScore = new BestScore(points);

        string json = JsonUtility.ToJson(bestScore);

        File.WriteAllText(Application.dataPath + "\\bestScore.json", json);


    }


}

public class BestScore
{
    public int bestScore;

    public BestScore(int bestScore)
    {
        this.bestScore = bestScore;
    }
}
