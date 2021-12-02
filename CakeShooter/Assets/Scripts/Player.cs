using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5.0f;

    float minX;
    float maxX;
    float padding = 0.5f;

    CakeRecipeCreator recipeCreator;

    // Start is called before the first frame update
    void Start()
    {
        SetBounds();
        recipeCreator = FindObjectOfType<CakeRecipeCreator>();
    }

    private void SetBounds()
    {
        var gameCam = Camera.main;
        minX = gameCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = gameCam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float newXPos = Mathf.Clamp((transform.position.x + deltaX), minX, maxX);
        transform.position = new Vector2(newXPos, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CakeLayer")
        {
            Debug.Log("COLLIDED WITH PLAYER " + collision.gameObject.name);
            recipeCreator.AddLayer(collision.gameObject.GetComponent<Ingredient>());

        }
    }

    public float GetXPos()
    {
        return transform.position.x;
    }
}
