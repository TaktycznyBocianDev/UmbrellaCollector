
# Umbrella The Game

Mała gra oparta na zbieraniu przedmiotów — kropel deszczu — spadających z góry.
Gracz steruje parasolką, która niejako chroni jej posiadacza przed zmoknięciem.

Jednym z najważniejszych wyzwań w tym projekcie była presja czasu — projekt bowiem od początku do końca zajął mi 1h 29min 11sec.





## Zdobyte doświadczenie:

- praca z Unity pod presją czasu
- Game menu 
- mechanika "Best Score"
- dopracowywanie projektu wg wskazówek "klienta"
## Features

- Lokalne best score
- Mechanika HP oraz punktów
- Poruszanie
- UI
- Prefabs oraz ich tworzenie na scenie
- Muzyka i dzwięki w grze


## O samej grze


W swoich założeniach jest ona bardzo prosta. Gracz steruje parasolem na dole ekranu
przesuwając go w lewo bądź w prawo. W ten sposób łapie krople, które spadają z góry. 

Gracz ma 5 punktów hp, pokazanych jako pasek. Po przegranej na ekranie wyświetlany jest wynik w danej rundzie oraz najlepszy wynik lokalny.


## Best Score 

Mechanika zliczania punktów oraz zapisywania najwyższego wyniku znajduje się w BestScoreSystem.cs.

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

Cały trzon mechaniki znajduje się w tej funkcji - możemy albo stworzyć zupełnie nowy zapis przy pierwszej grze, albo sprawdzić, czy uzyskane punkty faktycznie są nowym najlepszym wynikiem. Jeśli tak, nadpisujemy plik .json. Jeśli nie - tylko wyświetlamy rezultat oraz odczytany najlepszy wynik.



## Rain Maker

Rain maker to skrypt mający na celu tworzyć nowe krople wody na górze sceny. One natomiast są prefabem - przygotowanym wcześniej obiektem do kopiowania.
Zastosowanie ma tu także Coroutine, pozwalająca rozłożyć pojawianie się kropel - MakeWaterDrop() - w czasie. 

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
Początek gry

![App Screenshot](https://github.com/TaktycznyBocianDev/UmbrellaCollector/blob/main/Screens/2.jpg?raw=true)
Parasolka przy pracy :)

![App Screenshot](https://github.com/TaktycznyBocianDev/UmbrellaCollector/blob/main/Screens/3.jpg?raw=true)
Ukazanie nowego najwyższego wyniku


