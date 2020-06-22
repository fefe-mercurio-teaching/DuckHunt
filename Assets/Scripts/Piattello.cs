using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piattello : MonoBehaviour
{
    public GameController gameController;

    private void OnMouseDown()
    {
        //GameController controllerComponent = gameController.GetComponent<GameController>();
        gameController.score++;

        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(0.1f, 0f, 0f);

        if (transform.position.x > 50f)
        {
            Destroy(gameObject);
        }
    }
}
