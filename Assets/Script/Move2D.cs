using UnityEngine;

public class Move2D : MonoBehaviour
{
    //Vitesse du joueur
    public int speed;
    //Orientation du joueur
    private Vector2 direction;
    //Rigidbody
    private new Rigidbody2D rigidbody;

    //Déplacement
    public void Move(Vector2 newDirection)
    {
        direction = newDirection.normalized;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //Mise a jour de la vitesse
        rigidbody.velocity = direction * speed;
    }
}