using System;
using System.Collections;
using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour
{
    //Script externe
    private Move2D move2D;
    private Shooter shooter;
    //Cadence de tire
    [SerializeField] private float cadence;
    //hitbox
    private new Collider2D collider;

    private void Awake()
    {
        move2D = GetComponent<Move2D>();
        shooter = GetComponent<Shooter>();
        collider = GetComponent<Collider2D>();
    }

    void Start()
    {
        move2D.Move(Vector2.down);
        StartCoroutine(Shooting());
    }
    
    //Tir en continue
    private IEnumerator Shooting()
    {
        while (true)
        {
            //tir
            shooter.Shoot(Vector2.down);
            //attente jusqu'au prochain tir
            yield return new WaitForSeconds(cadence);
        }
    }

    //Active la hitbox de l'ennemi une fois en jeu
    void OnBecameVisible()
    {
        collider.enabled = true;
    }
}
