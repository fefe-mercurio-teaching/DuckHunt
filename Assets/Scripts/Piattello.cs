using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piattello : MonoBehaviour
{
    public GameController gameController;

    public float speed;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    private void OnMouseDown()
    {
        gameController.AddScore(1);

        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(speed * gameController.Level * 0.3f, 0f, 0f);

        if (transform.position.x > 27f || transform.position.x < -27f)
        {
            Destroy(gameObject);
            gameController.LoseOneLife();
        }
    }
}
