using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Cake Recipe")]
public class CakeRecipe : ScriptableObject
{  
    [SerializeField] List<Ingredient> cakeLayers;


    public List<Ingredient> GetCakeLayers()
    {
        return cakeLayers;
    }

}
