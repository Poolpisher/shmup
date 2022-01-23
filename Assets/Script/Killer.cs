using UnityEngine;
using UnityEngine.InputSystem;

public class Killer : MonoBehaviour
{
    //Script externe
    private PlayerBehaviour playerBehaviour;
    private PlayerInput playerInput;

    //Lors d'une collision
    void OnTriggerEnter2D(Collider2D other)
    {
        //Si la collision est faite avec un ennemie
        if (other.gameObject.CompareTag("Ennemy"))
        {
            //Détruit l'ennemi
            Destroy(other.gameObject);
            //Augmente le score
            Score.score = Score.score + 100;
        }
        //Si la collision est faite avec le player
        else if (other.gameObject.CompareTag("Player"))
        {
            //Désactive le rendu du joueur
            other.GetComponent<Renderer>().enabled = false;
            //Désactive le collider du joueur
            other.GetComponent<Collider2D>().enabled = false;
            //Désactive les inputs du joueur
            playerInput = other.GetComponent<PlayerInput>();
            playerInput.actions.FindActionMap("Player").Disable();
            //Met à jour le nombre de vie dans le HUD et lance le compte à rebours avant le respawn
            playerBehaviour = other.gameObject.GetComponent<PlayerBehaviour>();
            playerBehaviour.OnKill();
        }
    }
}    
