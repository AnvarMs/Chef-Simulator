using TMPro;
using UnityEngine;

public class PlayerIntraction : MonoBehaviour
{

    IIntractable C_Intractable;

    private PlayerInputAction inputSystem;
    
    private void Awake()
    {
        inputSystem = new PlayerInputAction();
        inputSystem.Enable();
        inputSystem.Player.Interact.started += Interact_started;
        inputSystem.Player.Interact.canceled += Interact_canceled;

    }

    private void Interact_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (C_Intractable != null)
            C_Intractable.CancelIntract();
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
