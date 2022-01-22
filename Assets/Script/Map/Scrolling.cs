using UnityEngine;

public class Scrolling : MonoBehaviour
{
    //Vitesse du scrolling
    public Vector2 speed = new Vector2(10, 10);

    //Direction du scrolling
    public Vector2 direction = new Vector2(-1, 0);

    //Loop du scrolling
    public bool isLooping = false;

    //Position en y actuelle
    private float objectHeight;
    //Position en y max
    [SerializeField] private float objectMaxHeight;
    
    void Update()
    {
        //Met à jour la position du scrolling
        objectHeight = transform.position.y;
        //Mouvement du scrolling
        Vector3 movement = new Vector3(speed.x*direction.x, speed.y*direction.y, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);

        //Reset le scrolling
        if (isLooping && objectHeight <= objectMaxHeight)
        {
            transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}