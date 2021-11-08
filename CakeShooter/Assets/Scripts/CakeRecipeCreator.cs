using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeRecipeCreator : MonoBehaviour
{
    [SerializeField] List<CakeRecipe> cakeRecipes;
    int currentRecipe = 0;
    CakeRecipe currentCake;

    // Start is called before the first frame update
    void Start()
    {
        currentCake = cakeRecipes[0];

        foreach(GameObject layerPrefab in cakeRecipes[0].GetCakeLayers())
        {
            GameObject layer = Instantiate(layerPrefab, transform.position, transform.rotation) as GameObject;
        }

        GameObject top = Instantiate(currentCake.GetTop(), transform.position, transform.rotation) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
