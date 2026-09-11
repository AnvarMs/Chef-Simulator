using UnityEngine;

public class Meet : MonoBehaviour,Iingredient,ICookeble
{
    public Ingredient item;

    public GameObject beforCook, afterCook;
    public bool isCooked = false;
    public void Cookitem()
    {
        beforCook.SetActive(false);
        afterCook.SetActive(true);
        isCooked = true;
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
        return 0;
    }
    public Ingredient GetIngredient()
    {
        return item;
    }
    public bool IsCooked()
    {
        return isCooked;
    }
}
