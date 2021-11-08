using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Cake Recipe")]
public class CakeRecipe : ScriptableObject
{

    [SerializeField] List<GameObject> cakeLayers;
    [SerializeField] GameObject cakeTop;

    public List<GameObject> GetCakeLayers()
    {
        return cakeLayers;
    }

    public GameObject GetTop()
    {
        return cakeTop;
    }
}
