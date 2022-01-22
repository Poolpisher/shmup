using UnityEngine;

//Nouveau type de variable applicable aux autres script qui contient les informations des ennemies
[System.Serializable]
public class Wave
{
    //Paramètre de la vague

    //Musique de la vague
    public AudioClip music;
    //Apparitions des ennemies
    public GameObject[] ennemies;
    //Quel spawn
    public GameObject[] spawn;
    //Temps entre chaque spawn
    public float[] time;
}
