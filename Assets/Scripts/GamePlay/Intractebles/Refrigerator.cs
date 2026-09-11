using UnityEngine;

public class Refrigerator : MonoBehaviour,IIntractable
{

    public GameObject refrigeratorUI;
    public GameObject[] ItemData;
    private int selectedID = -1;


    public void Intract()
    {
        selectedID = -1;
        ShowUi();

    }

    public void OnSelectIngrediant(int id)
    {
        selectedID =  id;
    }
    public void ShowUi()
    {
        refrigeratorUI.SetActive(true);
    }
    public void HideUi()
    {
        refrigeratorUI.SetActive(false);
        if (selectedID == -1) return;
        GameObject obj = Instantiate(ItemData[selectedID]);
        Inventory.Instance.SetItem(obj);
        
    }

    

    public void CancelIntract()
    {
       
    }
}
