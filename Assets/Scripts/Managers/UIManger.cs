using System.Collections;
using TMPro;
using UnityEngine;

public class UIManger : MonoBehaviour
{

    public static UIManger Instance;
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

    public TextMeshProUGUI ItemNameText;
    public TextMeshProUGUI WarningMsgText;
    public TextMeshProUGUI instructionText;

    private void Start()
    {
        OnCollectItem(PlayerIntraction.itemInInHand);
    }
    public void OnCollectItem(Ingredient ingredient)
    {
        ItemNameText.text = ingredient.ToString();
    }

    public void ShowWarning(string message)
    {
        StartCoroutine(Warning(message));
    }


    private IEnumerator Warning(string msg)
    {
        WarningMsgText.text = msg;
        WarningMsgText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        WarningMsgText.gameObject.SetActive(false);
        WarningMsgText.text = "";
        

    }

    public void ShowIntractionInfo()
    {
        instructionText.gameObject.SetActive(true);
    }
    public void DisableIntractionInfo()
    {
        instructionText.gameObject.SetActive(false);
    }
}
