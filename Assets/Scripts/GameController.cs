using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject piattelloOriginale;

    [Header("Componenti testo")]
    [SerializeField] UnityEngine.UI.Text levelText;
    [SerializeField] UnityEngine.UI.Text scoreText;
    [SerializeField] UnityEngine.UI.Text livesText;
    [SerializeField] UnityEngine.UI.Text gameOverText;
    [SerializeField] UnityEngine.UI.Text highScoreText;
    [SerializeField] UnityEngine.UI.Button startButton;

    [Header("Posizioni")]
    public float minRandomY = 3.5f; // Per la posizione Y del piattello 
    public float maxRandomY = 10f;  // genera un numero tra minRandomY e maxRandomY

    public float minRandomZ = 7f;   // Per la posizione Z del piattello 
    public float maxRandomZ = 12f;  // genera un numero tra minRandomZ e maxRandomZ

    [Header("Parametri")]
    public int startLives = 10;     // Vite iniziali
    public float spawnTime = 2f;    // Dopo quanti secondi genera il prossimo piattello

    int score = 0;                  // Punteggio raggiunto
    int lives = 1;                 // Vite a disposizione


    float elapsedTime = 0f;         // Secondi passati dalla generazione dell'ultimo piattello

    public int Level { get; private set; }

    bool gameStarted = false;

    void Start()
    {
        Level = 1;
        score = 0;
        lives = startLives;

        UpdateLevelText();
        UpdateScoreText();
        UpdateLivesText();
    }

    void UpdateLivesText()
    {
        livesText.text = "Vite: " + lives;
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
        startButton.gameObject.SetActive(false);
        gameStarted = true;
    }

    public void RestartGame()
    {
        gameOverText.gameObject.SetActive(false);
        score = 0;
        lives = startLives;
        Level = 1;

        gameStarted = true;

        UpdateLevelText();
        UpdateLivesText();
        UpdateScoreText();
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

    public void LoseOneLife()
    {
        lives--;

        if (lives == 0)
        {
            GameOver();
        }

        UpdateLivesText();
    }

    void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameStarted = false;

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Piattello"))
        {
            Destroy(obj);
        }

        int highScore = PlayerPrefs.GetInt("HighScore");

        if (score > highScore)
        {
            highScore = score;
            
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        highScoreText.text = "Punteggio più alto: " + highScore;
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
