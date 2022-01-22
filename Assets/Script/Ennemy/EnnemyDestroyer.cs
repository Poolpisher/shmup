using UnityEngine;

public class EnnemyDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ennemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
