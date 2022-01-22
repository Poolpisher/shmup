using UnityEngine;

public class Shooter : MonoBehaviour
{
    //Endroit d'ou part le projectile
    public Transform canon;
    //Prefab du projectile
    public GameObject projectile;

    public void Shoot(Vector2 direction)
    {
        //Création du projectile
        var newProjectile = Instantiate(projectile, canon.position, Quaternion.identity);
        //Déplacement du projectile
        var move2D = newProjectile.GetComponent<Move2D>();
        move2D.Move(direction);
    }
}
