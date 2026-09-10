using UnityEngine;

public class Trash : MonoBehaviour,IIntractable
{
    public void Intract()
    {
        DismantleItem();
    }
    private void DismantleItem()
    {
        if (PlayerIntraction.itemInInHand == Ingredient.Empty){
            UIManger.Instance.ShowWarning("No item to Dismatle");
            return;
            }

        else{

            UIManger.Instance.ShowWarning($"{PlayerIntraction.itemInInHand.ToString()} Dismantled");
        PlayerIntraction.itemInInHand = Ingredient.Empty;
        UIManger.Instance.OnCollectItem(Ingredient.Empty);
                }
    }
    
}
