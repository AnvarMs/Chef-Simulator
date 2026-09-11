using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public DelivoryWindow[] deliveryWindows;

    private void Start()
    {
        
        foreach (DelivoryWindow w in deliveryWindows)
        {
            if (w != null)
                w.Init(this);
                w.StartOrder();
        }
    }

    public void OnOrderFinished(DelivoryWindow window)
    {
        if (GameManager.Instance == null || GameManager.Instance.IsGameOver()) return;
        window.StartOrder();
    }

    public Ingredient[] GenerateOrder()
    {
        int count = Random.value < 0.5f ? 2 : 3;
        Ingredient[] order = new Ingredient[count];
        for (int i = 0; i < count; i++)
            order[i] = (Ingredient)Random.Range(0, 3);
        return order;
    }
}