using UnityEngine;

public class Cheese : MonoBehaviour,Iingredient
{
    public Ingredient item;

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
    public Ingredient GetIngredient()
    {
        return item;
    }

}
