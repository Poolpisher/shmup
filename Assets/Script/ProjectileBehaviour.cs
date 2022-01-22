using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ennemy") || other.gameObject.CompareTag("Player") )
        {
            Destroy(other.gameObject);
        }
    }
}    
