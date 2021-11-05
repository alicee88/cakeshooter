using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Cake Recipe")]
public class CakeRecipe : ScriptableObject
{
    [SerializeField] GameObject cakeLayer1;
    [SerializeField] GameObject cakeLayer2;
    [SerializeField] GameObject cakeTop;

    public GameObject GetFirstLayer()
    {
        return cakeLayer1;
    }

    public GameObject GetSecondLayer()
    {
        return cakeLayer2;
    }

    public GameObject GetTop()
    {
        return cakeTop;
    }
}
