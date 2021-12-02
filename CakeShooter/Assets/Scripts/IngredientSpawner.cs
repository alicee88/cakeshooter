using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> ingredients;
    float maxWaitTime = 1.5f;
    float minWaitTime = 1.0f;
    
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
            float waitTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
