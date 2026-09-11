using System.Collections;
using TMPro;
using UnityEngine;

public class Stove : MonoBehaviour,IIntractable
{
    public float cookTimer = 5;

    public Transform item1PlacePos, item2PlacePos;
    public GameObject item1, item2;
    public TextMeshProUGUI item1Text, item2Text;
    private GameObject eItem;
    public void Intract()
    {
        eItem = Inventory.Instance.GetItem();


        if (eItem != null)
        {
            ICookeble cookable = eItem.GetComponent<ICookeble>();

            // Holding a cooked item -> return it to inventory
            if (cookable != null && cookable.IsCooked())
            {
                ReturnItemToInv(eItem);

                UIManger.Instance.ShowWarning(
                    $"{eItem.GetComponent<Iingredient>().GetName()} is collected"
                );

                return;
            }

            if (item1 != null && item2 != null)
            {
                UIManger.Instance.ShowWarning("Stove is full");
                ReturnItemToInv(eItem);
                return;
            }

            if (cookable!=null&& !cookable.IsCooked()){
                TryCookItem(eItem);
                return;
            }

            UIManger.Instance.ShowWarning("Item is not cookable");
            ReturnItemToInv(eItem);
            return;
        }
        else
        {




            if (item1 != null && item1.GetComponent<ICookeble>().IsCooked())
            {
                CollectItem(ref item1);
                return;
            }

            if (item2 != null && item2.GetComponent<ICookeble>().IsCooked())
            {
                CollectItem(ref item2);
                return;
            }



        }

       
    }



    private void ReturnItemToInv(GameObject obj)
    {
        Inventory.Instance.SetItem(obj);
    }
    private void CollectItem(ref GameObject item)
    {
        GameObject collectedItem = item;
        item = null;

        ReturnItemToInv(collectedItem);

        UIManger.Instance.ShowWarning(
            $"{collectedItem.GetComponent<Iingredient>().GetName()} is collected"
        );
    }

    private void TryCookItem(GameObject obj)
    {
        if (item1 == null)
        {
            item1 = obj;

            item1.transform.SetParent(item1PlacePos);
            item1.transform.position = item1PlacePos.position;

            StartCoroutine(CookItem(item1Text, item1.GetComponent<ICookeble>()));

            UIManger.Instance.ShowWarning(
                $"{obj.GetComponent<Iingredient>().GetName()} is Cooking"
            );
        }
        else if (item2 == null)
        {
            item2 = obj;

            item2.transform.SetParent(item2PlacePos);
            item2.transform.position = item2PlacePos.position;

            StartCoroutine(CookItem(item2Text, item2.GetComponent<ICookeble>()));

            UIManger.Instance.ShowWarning(
                $"{obj.GetComponent<Iingredient>().GetName()} is Cooking"
            );
        }
        else
        {
            // Stove is full, give item back to player
            ReturnItemToInv(obj);

            UIManger.Instance.ShowWarning("Stove is full");
        }
    }




    private IEnumerator CookItem(TextMeshProUGUI timerText,ICookeble cookeble)
    {


        float time = cookTimer;
        while (time > 0)
        {

            timerText.text = time.ToString();
            yield return new WaitForSeconds(1);
            time--;
        }
        timerText.text = "";
        cookeble.Cookitem();

    }
    public void CancelIntract()
    {
       
    }
}
