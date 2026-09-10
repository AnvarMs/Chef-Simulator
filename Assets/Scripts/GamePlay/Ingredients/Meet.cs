using UnityEngine;
using static UnityEditor.Progress;

public class Meet : MonoBehaviour,Iingredient,ICookeble
{
    public Ingredient item;

    public void Cookitem()
    {
        throw new System.NotImplementedException();
    }

    public string GetName()
    {
        return item.ToString();
    }

    public GameObject GetObjectRef()
    {
        return gameObject;
    }

    public int GetPoint()
    {
        throw new System.NotImplementedException();
    }

    public bool IsCooked()
    {
        throw new System.NotImplementedException();
    }
}
