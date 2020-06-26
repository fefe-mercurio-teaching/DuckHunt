using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCube : MonoBehaviour
{
    public GameController gameController;
    public UnityEngine.UI.Text startText;
    
    MeshRenderer renderer;

    public Color selectedColor = Color.red;
    public Color notSelectedColor = Color.white;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();

        renderer.material.color = notSelectedColor;
    }

    private void OnMouseDown()
    {
        gameController.StartGame();
        gameObject.SetActive(false);
        startText.gameObject.SetActive(false);
    }

    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

        renderer.material.color = selectedColor;
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);

        renderer.material.color = notSelectedColor;
    }
}
