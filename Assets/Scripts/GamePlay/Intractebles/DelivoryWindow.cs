using System.Collections;
using TMPro;
using UnityEngine;

public class DelivoryWindow : MonoBehaviour,IIntractable
{


    public float timer = 0;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI ingrediantsText;

    public Transform[] itemPlacePos;
    private int itemplaceCount = 0;
    OrderManager orderManager;

    Ingredient[] orders;
    private bool isOrderOnline;

    private bool[] progress;
    private int baseScore = 0;
    public void Init(OrderManager manager)
    {
        orderManager = manager;

    }


    public void StartOrder()
    {
        orders = orderManager.GenerateOrder();
        progress = new bool[orders.Length];
        itemplaceCount = 0; 

        baseScore = 0;
        baseScore = GetOrderBaseScore();

        isOrderOnline = true;
        timer = 0;

        foreach (Transform i_Pos in itemPlacePos)
        {
            for (int i = i_Pos.childCount - 1; i >= 0; i--)
            {
                Destroy(i_Pos.GetChild(i).gameObject);
            }
        }

        RefreshIngredientText();
    }

    private int GetOrderBaseScore()
    {
        int total = 0;
        foreach (Ingredient ing in orders)
        {
            switch (ing)
            {
                case Ingredient.Meet: total += 30; break;
                case Ingredient.Cheese: total += 10; break;
                case Ingredient.Vegetables: total += 20; break;
            }
        }
        return total;
    }

    public void CancelIntract()
    {
        
    }

    public void Intract()
    {

        GameObject item = Inventory.Instance.GetItem();
        if (item == null) return;

        Ingredient itemIng = item.GetComponent<Iingredient>().GetIngredient();

        
        int matchedIndex = -1;
        for (int i = 0; i < orders.Length; i++)
        {
            if (orders[i] == itemIng && !progress[i])
            {
                matchedIndex = i;
                break;
            }
        }

        if (matchedIndex == -1)
        {
            Inventory.Instance.SetItem(item);
            UIManger.Instance.ShowWarning("Wrong Ingredient");

            return;
        }

       
        switch (itemIng)
        {
            case Ingredient.Vegetables:
                IChoppeble chopped = item.GetComponent<IChoppeble>();
                if (chopped == null || !chopped.IsChopped())
                {
                    Inventory.Instance.SetItem(item);
                    UIManger.Instance.ShowWarning("Vegetable needs to be chopped!");
                    return;
                }
                break;

            case Ingredient.Meet:
                ICookeble cooked = item.GetComponent<ICookeble>();
                if (cooked == null || !cooked.IsCooked())
                {
                    Inventory.Instance.SetItem(item);
                    UIManger.Instance.ShowWarning("Meat needs to be cooked!");
                    return;
                }
                break;

            case Ingredient.Cheese:
                
                break;
        }

        progress[matchedIndex] = true;
        RefreshIngredientText();
        item.transform.SetParent(itemPlacePos[itemplaceCount]);
        item.transform.localPosition = Vector3.zero;
        itemplaceCount++;

        UIManger.Instance.ShowWarning($"{itemIng.ToString()} added to dish");
        IsOrderCompleate();
       
    }

    public void IsOrderCompleate()
    {
        
        foreach(bool i in progress)
        {
            if (!i)
            {
                isOrderOnline = true;

                return;
            }
        }

        isOrderOnline = false;
        OnOrderCompleate();
    }

    private void OnOrderCompleate()
    {
        int finalScore = baseScore - Mathf.FloorToInt(timer);
        GameManager.Instance.AddScore(finalScore);
        orderManager.OnOrderFinished(this);
    }

    private void CancelOrder()
    {
        isOrderOnline = false;
        UIManger.Instance.ShowWarning("Order expired!");
        orderManager.OnOrderFinished(this);
    }

    private void RefreshIngredientText()
    {
        string result = "";
        for (int i = 0; i < orders.Length; i++)
        {
            result += (progress[i] ? "<color=#00FF00>O</color> " : "<color=#FF0000>X</color> ")
    + orders[i] + "\n";

        }
        ingrediantsText.text = result;
    }
  
    private void Update()
    {
        if (!isOrderOnline || GameManager.Instance.IsGameOver()) return;

        timer += Time.deltaTime;
        timerText.text = $"{Mathf.FloorToInt(timer)}s";

        int elapsed = Mathf.FloorToInt(timer);
        if (elapsed >= baseScore)
        {
            CancelOrder();
            return;
        }

        int currentScore = baseScore - elapsed;
        timerText.color = currentScore <= 0 ? Color.red : Color.white;
    }




}
