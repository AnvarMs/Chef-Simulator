using System.Collections;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

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
            ICookeble t_cookeble = eItem.GetComponent<ICookeble>();
            if (t_cookeble != null)
            {
                if (!t_cookeble.IsCooked())
                {
                    TryCookItem(eItem);
                }
                else
                {
                    UIManger.Instance.ShowWarning("Item already cooked");
                    ReturnItemToInv(eItem);
                }
            }
            else
            {
                UIManger.Instance.ShowWarning("Item is not cookeble");

                ReturnItemToInv(eItem);
            }
            
        }
        else
        {
            if (item1 != null && item1.GetComponent<ICookeble>().IsCooked())
            {
                ReturnItemToInv(item1);
                UIManger.Instance.ShowWarning($"{item1.GetComponent<Iingredient>().GetName()} is collected");
                return;
            }
            if (item2 != null && item2.GetComponent<ICookeble>().IsCooked())
            {
                ReturnItemToInv(item2);
                UIManger.Instance.ShowWarning($"{item2.GetComponent<Iingredient>().GetName()} is collected");
                return;
            }

        }
    }
    
    private void ReturnItemToInv(GameObject obj)
    {
        Inventory.Instance.SetItem(obj);
    }
    private void TryCookItem(GameObject obj)
    {
        if (item1 == null)
        {
            item1 = obj;
            item1.transform.SetParent(item1PlacePos);
            item1.transform.position = item1PlacePos.position;
            StartCoroutine(CookItem(item1Text, item1.GetComponent<ICookeble>()));
        }else if(item2 == null)
        {
            item2 = obj;
            item2.transform.SetParent(item2PlacePos);
            item2.transform.position = item2PlacePos.position;
            StartCoroutine(CookItem(item2Text, item2.GetComponent<ICookeble>()));
        }
        else
        {
            UIManger.Instance.ShowWarning("Stove is full");
            return;
        }


        UIManger.Instance.ShowWarning($"{obj.GetComponent<Iingredient>().GetName()} is Cooking");

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
