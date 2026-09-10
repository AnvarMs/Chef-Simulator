using UnityEngine;

public class Refrigerator : MonoBehaviour,IIntractable,IitemCollecteble
{

    public GameObject refrigeratorUI;
    private Ingredient selectedIngrediant;
    public void Intract()
    {
        ShowUi();
    }

    public void OnSelectIngrediant(int n)
    {
        selectedIngrediant = (Ingredient)n;
    }
    public void ShowUi()
    {
        refrigeratorUI.SetActive(true);
    }
    public void HideUi()
    {
        refrigeratorUI.SetActive(false);
        if (PlayerIntraction.itemInInHand == Ingredient.Empty)
        {
            PlayerIntraction.itemInInHand = CollectItem();
            UIManger.Instance.OnCollectItem(CollectItem());
        }
        else
        {
            UIManger.Instance.ShowWarning("Inventory is full");
        }
    }

    public Ingredient CollectItem()
    {
        
        return selectedIngrediant;
    }

    public bool IsItemReady()
    {
        return true;
    }
}
