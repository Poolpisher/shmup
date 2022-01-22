using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOOB : MonoBehaviour
{
    void OnBecameInvisible()
    {
        //détruit le projectile une fois hors de portée de la caméra
        Destroy(gameObject);
    }
}
