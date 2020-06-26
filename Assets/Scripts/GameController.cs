using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject piattelloOriginale;
    public UnityEngine.UI.Text levelText;
    public UnityEngine.UI.Text scoreText;

    public float minRandomY = 3.5f; // Per la posizione Y del piattello 
    public float maxRandomY = 10f;  // genera un numero tra minRandomY e maxRandomY

    public float minRandomZ = 7f;   // Per la posizione Z del piattello 
    public float maxRandomZ = 12f;  // genera un numero tra minRandomZ e maxRandomZ

    int score = 0;                  // Punteggio raggiunto

    public float spawnTime = 2f;    // Dopo quanti secondi genera il prossimo piattello

    float elapsedTime = 0f;         // Secondi passati dalla generazione dell'ultimo piattello

    public int Level { get; private set; }

    bool gameStarted = false;

    void Start()
    {
        Level = 1;
        score = 0;

        UpdateLevelText();
        UpdateScoreText();
    }

    void UpdateLevelText()
    {
        levelText.text = "Livello " + Level;
    }

    void UpdateScoreText()
    {
        scoreText.text = $"Punti: {score}/{Level * 10}";
    }

    public void StartGame()
    {
        gameStarted = true;
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();

        if (score >= Level * 10)
        {
            Level++;
            UpdateLevelText();
        }
    }

    void Update()
    {
        if (gameStarted)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= spawnTime)
            {
                GameObject nuovoPiattello = Instantiate(piattelloOriginale);
                Piattello componentePiattello = nuovoPiattello.GetComponent<Piattello>();

                float randomY = Random.Range(minRandomY, maxRandomY);
                float randomZ = Random.Range(minRandomZ, maxRandomZ);

                if (Random.Range(0f, 1f) < .5f)
                {
                    nuovoPiattello.transform.position = new Vector3(-25f, randomY, randomZ);
                }
                else
                {
                    nuovoPiattello.transform.position = new Vector3(25f, randomY, randomZ);
                    componentePiattello.speed *= -1f;
                }

                nuovoPiattello.SetActive(true);

                elapsedTime = 0f;
            }
        }
    }
}
