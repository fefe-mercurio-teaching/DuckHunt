using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject piattelloOriginale;

    public float minRandomY = 3.5f; // Per la posizione Y del piattello 
    public float maxRandomY = 10f;  // genera un numero tra minRandomY e maxRandomY

    public float minRandomZ = 7f;   // Per la posizione Z del piattello 
    public float maxRandomZ = 12f;  // genera un numero tra minRandomZ e maxRandomZ

    public int score = 0;           // Punteggio raggiunto

    public float spawnTime = 2f;    // Dopo quanti secondi genera il prossimo piattello

    float elapsedTime = 0f;         // Secondi passati dalla generazione dell'ultimo piattello

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnTime)
        {
            GameObject nuovoPiattello = Instantiate(piattelloOriginale);

            float randomY = Random.Range(minRandomY, maxRandomY);
            float randomZ = Random.Range(minRandomZ, maxRandomZ);

            nuovoPiattello.transform.position = new Vector3(-25f, randomY, randomZ);
            
            nuovoPiattello.SetActive(true);

            elapsedTime = 0f;

            Debug.Log("Genero un piattello");
        }
    }
}
