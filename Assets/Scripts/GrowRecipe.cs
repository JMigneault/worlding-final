using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GrowRecipe", order = 1)]
public class GrowRecipe : ScriptableObject
{

    public GameObject[] elements;
    public int[] elementNums;

}
