using System.Collections;
using TMPro;
using UnityEngine;


public class Table : MonoBehaviour,IIntractable
{
    public float choopTime = 2f;

    public TextMeshProUGUI timerText;

    public Transform itemPlacePos;
    private Coroutine chooping;
    private GameObject item;
    private IChoppeble choppeble;
    private bool IsChopped;
    public void Intract()
    {
        Chopp();
    }


    private void Chopp()
    {
        item = Inventory.Instance.GetItem();

        // No item
        if (item == null)
        {
            UIManger.Instance.ShowWarning("No Item to Chop");
            return;
        }

        // Item is not choppable
        choppeble = item.GetComponent<IChoppeble>();

        if (choppeble == null)
        {
            UIManger.Instance.ShowWarning("Item Not Choppable");
            Inventory.Instance.SetItem(item);
            return;
        }

        // Item is already chopped
        if (choppeble.IsChopped())
        {
            UIManger.Instance.ShowWarning("Item already chopped");
            Inventory.Instance.SetItem(item);
            return;
        }

        // Everything is valid, start chopping
        item.transform.SetParent(itemPlacePos);
        item.transform.position = itemPlacePos.position;
        IsChopped = false;
        chooping = StartCoroutine(ChoopItem());

        UIManger.Instance.ShowWarning("Chopping the item");
    }


    public void CancelIntract()
    {
        if (choppeble == null) return;
        if (!IsChopped)
        {
            if(chooping!=null)
                StopCoroutine(chooping);

            choppeble.CancelChopping();
            timerText.text = "";
        }
        
        
            Inventory.Instance.SetItem(item);
        
    }


    private IEnumerator ChoopItem()
    {
        
        float time = choopTime;
        while (time > 0)
        {

            timerText.text = time.ToString();
            yield return new WaitForSeconds(1);
            time--;
        }
        IsChopped = true;
        timerText.text = "";
        choppeble.ChoppItem();
        
    }

   
}
