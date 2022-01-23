using UnityEngine.Events;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    //Event unity en cas de réussite
    [SerializeField] private UnityEvent onFinishingAllWaves;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void OnKill()
    {
        //Diminue le nombre de vie
        Life.life--;
        if (Life.life <= 0)
        {
            //Écran de game over
            onFinishingAllWaves.Invoke();
        }
        else
        {
            //Lance le respawn
            StartCoroutine(Respawn());
        }
    }
    
    private IEnumerator Respawn()
    {
        //attente jusqu'au respawn
        yield return new WaitForSeconds(2);
        //Réactive le rendu du joueur
        gameObject.GetComponent<Renderer>().enabled = true;
        //Réactive les inputs du joueur
        playerInput.actions.FindActionMap("Player").Enable();
        //Frames d'invincibilités
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
