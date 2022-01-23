using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Orientation du joueur
    private Vector2 moveInput;
    
    //Reference aux scripts
    private Shooter shooter;
    private Move2D move2D;

    private bool isShooting;
    private float lastShoot;
    [SerializeField] private float cadence;
    
    // Start is called before the first frame update
    void Awake()
    {
        move2D = GetComponent<Move2D>();
        shooter = GetComponent<Shooter>();
    }
    
    //Déplacement
    public void Move(InputAction.CallbackContext obj)
    {
        moveInput = obj.ReadValue<Vector2>();
        move2D.Move(moveInput);
    }

    //Tir
    public void Shoot(InputAction.CallbackContext obj)
    {
        //Si la touche est maintenu
        if(obj.phase == InputActionPhase.Started || obj.phase == InputActionPhase.Performed)
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }
    }

    private void Update()
    {
        if (isShooting &&  Time.time > lastShoot + cadence)
        {
            shooter.Shoot(Vector2.up);
            //Changement de la valeur du dernier tir
            lastShoot = Time.time;
        }
    }
}
