using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public Transform handPos;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public Iingredient slote;

    public void SetItem(GameObject item)
    {
        if(slote!=null){
            UIManger.Instance.ShowWarning("Inventory is full");
            Destroy(item);
            return;
            }
        else
        {
            slote = item.GetComponent<Iingredient>();
            item.transform.SetParent(handPos, false);
            item.transform.position = handPos.transform.position;
            UIManger.Instance.OnCollectItem(slote.GetName());
        }

       
    }

    public GameObject GetItem()
    {
        if (slote == null) return null;
        GameObject item = slote.GetObjectRef();
        slote = null;
        return item;
    }
  
}
