using TMPro;
using UnityEngine;

public class PlayerIntraction : MonoBehaviour
{


    
    public static Ingredient itemInInHand;
    IIntractable C_Intractable;

    private PlayerInputAction inputSystem;
    
    private void Awake()
    {
        inputSystem = new PlayerInputAction();
        inputSystem.Enable();
        inputSystem.Player.Interact.started += Interact_started;
        itemInInHand = Ingredient.Empty;

    }

    private void Interact_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (C_Intractable != null)
            C_Intractable.Intract();
    }

    
    
  
    private void OnTriggerEnter(Collider other)
    {
         C_Intractable = other.transform.GetComponent<IIntractable>();
        UIManger.Instance.ShowIntractionInfo();
    }


    private void OnTriggerExit(Collider other)
    {
        C_Intractable = null;
        UIManger.Instance.DisableIntractionInfo();
    }

    
   

    private void OnDisable()
    {
        inputSystem.Dispose();
    }
}
