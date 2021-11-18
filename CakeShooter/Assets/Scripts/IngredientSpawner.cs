using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> ingredients;
    
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(SpawnIngredient());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnIngredient()
    {
        GameObject newIngredient;
        while (true)
        {
            newIngredient = ingredients[Random.Range(0, ingredients.Count)];
            Instantiate(newIngredient, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2.0f);
        }
    }
}
