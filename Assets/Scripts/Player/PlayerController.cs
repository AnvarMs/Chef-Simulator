using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody rb;
    private PlayerInputAction inputSystem;
    private Vector2 input;
    private void Awake()
    {
        inputSystem = new PlayerInputAction();
        inputSystem.Enable();
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
         input = inputSystem.Player.Move.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        Vector3 target = new Vector3(input.x, 0, input.y);
        
        rb.linearVelocity = target*speed;
        if(target.sqrMagnitude>.1f)
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(-input.y,0,input.x)),.2f);
        
    }

    private void OnDisable()
    {
        inputSystem.Disable();
    }
}
