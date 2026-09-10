using UnityEngine;

public enum Ingredient
{
    Meet,
    Cheese,
    Vegetables,
    Empty
}
public interface Iingredient
{
    public Ingredient GetName();
    public int GetPoint();
    public GameObject GetModelPreFab();
}
