using UnityEngine;

public class Trash : MonoBehaviour,IIntractable
{
    public void CancelIntract()
    {
        
    }

    public void Intract()
    {
        DismantleItem();
    }
    private void DismantleItem()
    {
        GameObject item = Inventory.Instance.GetItem();
        if (item == null){
            UIManger.Instance.ShowWarning("No item to Dismatle");
            return;
            }

        else{

            UIManger.Instance.ShowWarning($"{item.GetComponent<Iingredient>().GetName()} Dismantled");
            Destroy(item);
            UIManger.Instance.OnCollectItem("");
            }
    }
    
}
