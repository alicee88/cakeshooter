using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5.0f;

    float minX;
    float minY;
    float maxX;
    float maxY;
    float padding = 0.5f;
    float paddingRight = 2.0f;

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
        maxX = gameCam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - paddingRight;
        minY = gameCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = gameCam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        float newXPos = Mathf.Clamp((transform.position.x + deltaX), minX, maxX);
        float newYPos = Mathf.Clamp((transform.position.y + deltaY), minY, maxY);
        transform.position = new Vector2(newXPos, newYPos);
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
