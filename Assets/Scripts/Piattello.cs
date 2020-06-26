using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piattello : MonoBehaviour
{
    public GameController gameController;

    public float speed;

    private void OnMouseDown()
    {
        //GameController controllerComponent = gameController.GetComponent<GameController>();
        gameController.AddScore(1);

        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(speed * gameController.Level * 0.3f, 0f, 0f);

        if (transform.position.x > 50f)
        {
            Destroy(gameObject);
        }
    }
}
