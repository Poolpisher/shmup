using UnityEngine;

public class Boundaries : MonoBehaviour
{
    //Camera
    private Camera cam;
    //Taille de l'écran
    private Vector2 screenMin;
    private Vector2 screenMax;
    //Taille du player
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        cam = Camera.main;
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    void LateUpdate()
    {
        //Calcul de la taille de jeu disponible
        screenMin = cam.ViewportToWorldPoint(Vector2.zero);
        screenMax = cam.ViewportToWorldPoint(Vector2.one);
        //Vérifie si l'objet est bien dans la zone de jeu
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenMin.x + objectWidth, screenMax.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenMin.y + objectHeight, screenMax.y - objectHeight);
        //Replace l'objet
        transform.position = viewPos;
    }
}