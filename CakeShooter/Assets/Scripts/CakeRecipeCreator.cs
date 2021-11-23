using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeRecipeCreator : MonoBehaviour
{
    [SerializeField] List<CakeRecipe> cakeRecipes;
    [SerializeField] GameObject cakeParticlesPrefab;
    
    int currentRecipe = 0;
    int layersInRecipe = 0;
    CakeRecipe currentCake;
    List<Ingredient> ingredientsOnPlate;
    List<Ingredient> ingredientsInRecipe;

    // Start is called before the first frame update
    void Start()
    {
        
        currentCake = cakeRecipes[0];
        ingredientsOnPlate = new List<Ingredient>();
        ingredientsInRecipe = new List<Ingredient>();
        layersInRecipe = currentCake.GetCakeLayers().Count;
        StartCoroutine(CreateCake(cakeRecipes[0]));

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
                Ingredient middleLayer = ingredientsOnPlate[layersInRecipe / 2];
                Debug.Log("HOLY MOLY");
                GameObject cakeParticles = Instantiate(cakeParticlesPrefab, middleLayer.transform.position, Quaternion.identity) as GameObject;
                Destroy(cakeParticles, 0.5f);
                for(int j = 0; j < ingredientsOnPlate.Count; j++)
                {
                    Destroy(ingredientsOnPlate[j].gameObject);
                    Debug.Log("DESTROYED PLATE INGREDIENT " + ingredientsOnPlate[j].name);
                    Destroy(ingredientsInRecipe[j].gameObject);
                    Debug.Log("DESTROYED RECIPE INGREDIENT " + ingredientsInRecipe[j].name);
                }
                ingredientsOnPlate.Clear();
                ingredientsInRecipe.Clear();
                cakeFinished = true;
            }
        }
    }

    private IEnumerator CreateCake(CakeRecipe recipe)
    {
        foreach (Ingredient layerPrefab in recipe.GetCakeLayers())
        {
            Ingredient layer = Instantiate(layerPrefab, transform.position, transform.rotation) as Ingredient;
            ingredientsInRecipe.Add(layer);
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
