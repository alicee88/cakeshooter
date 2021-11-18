using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] FoodType foodType;

    bool onPlate = false;
    Player player;
    CakeRecipeCreator recipeCreator;

    public enum FoodType
    {
        PlainSponge,
        ChocSponge,
        Jam,
        Cream,
        WhiteIcing,
        ChocIcing,
        RaspberryTop,
        StrawberryTop
    }



    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        recipeCreator = FindObjectOfType<CakeRecipeCreator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(onPlate)
        {
            float newX = player.GetXPos();
            transform.position = new Vector2(newX, transform.position.y);
        }
    }

    public void SetOnPlate()
    {
        onPlate = true;
    }

    public bool IsOnPlate()
    {
        return onPlate;
    }

    public FoodType GetFoodType()
    {
        return foodType;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag != "Recipe" && tag == "CakeLayer")
        {
            if (collision.gameObject.GetComponent<Ingredient>())
            {
                if (!collision.gameObject.GetComponent<Ingredient>().IsOnPlate())
                {
                    recipeCreator.AddLayer(collision.gameObject.GetComponent<Ingredient>());
                    onPlate = true;
                }
            }
            


        }
    }
}
