using System.Collections;
using UnityEngine;

public class LosangePattern : MonoBehaviour
{
    public Vector2 direction = new Vector2(-1f, -1f);
    public Vector2 speed = new Vector2(1f, 1f);

    private bool canMove = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }
    
    private IEnumerator Move()
    {
        //attente jusqu'au mouvement
        yield return new WaitForSeconds(0.4f);
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            var movement = new Vector3(speed.x*direction.x, speed.y*direction.y, 0f);
            // Important: because of parent/child relations of this object, we need to translate it relative to Space.World, otherwise rotating the object, can actually change its position too...
            transform.Translate(movement.x*Time.deltaTime, movement.y*Time.deltaTime, 0, Space.World);
        }
    }
}
