using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    CakeRecipeCreator cakeCreator;

    // Start is called before the first frame update
    void Start()
    {
       cakeCreator = FindObjectOfType<CakeRecipeCreator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("COLLIDED WITH VACUUM");
            cakeCreator.CheckCakeIsFinished();
        }
        
    }
}
