using System.Collections;
using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour
{
    private Move2D move2D;
    private Shooter shooter;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float cadence;

    private void Awake()
    {
        move2D = GetComponent<Move2D>();
        shooter = GetComponent<Shooter>();
    }

    void Start()
    {
        move2D.Move(direction);
        StartCoroutine(Shooting());
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(player.gameObject);
        }
    }
    
    private IEnumerator Shooting()
    {
        while (true)
        {
            shooter.Shoot(Vector2.down);
            //attente jusqu'au prochain tir
            yield return new WaitForSeconds(cadence);
        }
    }
}
