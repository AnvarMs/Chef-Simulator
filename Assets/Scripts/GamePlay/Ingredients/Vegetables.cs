using UnityEngine;

public class Vegetables : MonoBehaviour, Iingredient, IChoppeble
{

    public Ingredient item;
    public GameObject beforChop, afterChop;
    private bool isChopped = false;
    public void CancelChopping()
    {
        isChopped = false;
    }

    public void ChoppItem()
    {
        isChopped = true;
        beforChop.SetActive(false);
        afterChop.SetActive(true);
    }
    public bool IsChopped()
    {
        return isChopped;
    }
    public string GetName()
    {
        return item.ToString();
    }
    public Ingredient GetIngredient()
    {
        return item;
    }

    public GameObject GetObjectRef()
    {
        return gameObject;
    }

    public int GetPoint()
    {
        throw new System.NotImplementedException();
    }

  
}
