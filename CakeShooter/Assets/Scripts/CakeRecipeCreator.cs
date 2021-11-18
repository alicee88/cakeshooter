using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeRecipeCreator : MonoBehaviour
{
    [SerializeField] List<CakeRecipe> cakeRecipes;
    
    int currentRecipe = 0;
    int layersInRecipe = 0;
    CakeRecipe currentCake;
    List<Ingredient> ingredientsOnPlate;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateCake(cakeRecipes[0]));
        currentCake = cakeRecipes[0];
        ingredientsOnPlate = new List<Ingredient>();
        layersInRecipe = currentCake.GetCakeLayers().Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (layersInRecipe == ingredientsOnPlate.Count)
        {
            bool cakeFinished = true;
            Debug.Log("GOT RIGHT NUMBER OF LAYERS");
            for(int i = 0; i < currentCake.GetCakeLayers().Count; i++)
            {
                Debug.Log("Cake layers: " + ingredientsOnPlate[i]);
                Debug.Log("Recipe layers: " + currentCake.GetCakeLayers()[i]);
                if(ingredientsOnPlate[i].GetFoodType() != currentCake.GetCakeLayers()[i].GetFoodType())
                {
                    cakeFinished = false;
                    Debug.Log("Ingredients don't match, abort");
                    return;
                }

            }
            
            if (cakeFinished)
            {
                Debug.Log("HOLY MOLY");
            }
        }
    }

    private IEnumerator CreateCake(CakeRecipe recipe)
    {
        foreach (Ingredient layerPrefab in cakeRecipes[0].GetCakeLayers())
        {
            Ingredient layer = Instantiate(layerPrefab, transform.position, transform.rotation) as Ingredient;
            layer.tag = "Recipe";
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void AddLayer(Ingredient layer)
    {
        ingredientsOnPlate.Add(layer);
        layer.GetComponent<Ingredient>().SetOnPlate();
        Debug.Log("ADDED LAYER " + layer.name);
    }
}
