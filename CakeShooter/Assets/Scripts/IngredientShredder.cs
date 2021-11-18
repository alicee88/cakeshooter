using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientShredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CakeLayer")
        {
            Destroy(collision.gameObject);
        }
    }
}
