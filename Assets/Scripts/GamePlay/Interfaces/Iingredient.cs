using UnityEngine;

public enum Ingredient
{
    Meet,
    Cheese,
    Vegetables
}
public interface Iingredient
{
    public Ingredient GetIngredient();
    public string GetName();
    public int GetPoint();
    public GameObject GetObjectRef();
}
