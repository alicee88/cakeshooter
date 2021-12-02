using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeRecipeCreator : MonoBehaviour
{
    [SerializeField] List<CakeRecipe> cakeRecipes;
    [SerializeField] GameObject cakeParticlesPrefab;
    [SerializeField] GameObject destroyedParticlesPrefab;
    
    int layersInRecipe = 0;
    CakeRecipe currentRecipe;
    List<Ingredient> ingredientsOnPlate;
    List<Ingredient> ingredientsInRecipe;

    // Start is called before the first frame update
    void Start()
    {
        
        ingredientsOnPlate = new List<Ingredient>();
        ingredientsInRecipe = new List<Ingredient>();
        SetNextRecipe();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CheckCakeIsFinished()
    {
        if (layersInRecipe == ingredientsOnPlate.Count)
        {
            if (CakeFinished())
            {
                Ingredient middleLayer = ingredientsOnPlate[layersInRecipe / 2];
                Debug.Log("HOLY MOLY");
                GameObject cakeParticles = Instantiate(cakeParticlesPrefab, middleLayer.transform.position, Quaternion.identity) as GameObject;
                Destroy(cakeParticles, 0.1f);
                DestroyCake(true);
                SetNextRecipe();
            }
            else
            {
                Debug.Log("Right number of ingredients but wrong cake");
                if(ingredientsOnPlate.Count > 0)
                {
                    SpawnDestroyedCakeParticles();
                }
                DestroyCake(false);
            }
        }
        else
        {
            Debug.Log("Not enough ingredients, destroying");
            if (ingredientsOnPlate.Count > 0)
            {
                SpawnDestroyedCakeParticles();
            }
            DestroyCake(false);
        }
    }

    private void SpawnDestroyedCakeParticles()
    {
        Ingredient middleLayer = ingredientsOnPlate[ingredientsOnPlate.Count / 2];
        GameObject destroyedParticles = Instantiate(destroyedParticlesPrefab, middleLayer.transform.position, Quaternion.identity) as GameObject;
        Destroy(destroyedParticles, 0.5f);
    }

    private void DestroyCake(bool destroyRecipe)
    {
        for (int i = 0; i < ingredientsOnPlate.Count; i++)
        {
            Destroy(ingredientsOnPlate[i].gameObject);
            Debug.Log("DESTROYED PLATE INGREDIENT " + ingredientsOnPlate[i].name);
            if (destroyRecipe)
            {
                Destroy(ingredientsInRecipe[i].gameObject);
                Debug.Log("DESTROYED RECIPE INGREDIENT " + ingredientsInRecipe[i].name);
            }
        }
        ingredientsOnPlate.Clear();
        if (destroyRecipe)
        {
            ingredientsInRecipe.Clear();
        }
    }

    private bool CakeFinished()
    {
        Debug.Log("GOT RIGHT NUMBER OF LAYERS");
        for (int i = 0; i < currentRecipe.GetCakeLayers().Count; i++)
        {
            Debug.Log("Cake layers: " + ingredientsOnPlate[i]);
            Debug.Log("Recipe layers: " + currentRecipe.GetCakeLayers()[i]);
            if (ingredientsOnPlate[i].GetFoodType() != currentRecipe.GetCakeLayers()[i].GetFoodType())
            {
                Debug.Log("Ingredients don't match, abort");
                return false;
            }
        }
        return true;
    }

    private void SetNextRecipe()
    {
        currentRecipe = cakeRecipes[Random.Range(0, cakeRecipes.Count)];
        layersInRecipe = currentRecipe.GetCakeLayers().Count;
        Debug.Log("LAYERS IN RECIPE IS " + layersInRecipe);
        StartCoroutine(CreateCake(currentRecipe));
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
