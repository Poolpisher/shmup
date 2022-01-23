using TMPro;
using UnityEngine;

public class Life : MonoBehaviour
{
    TextMeshProUGUI txt;
    public static int life = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        //Récupère le texte du HUD
        txt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //Mise à jour du nombres de vie dans le HUD
        txt.text = "" + life;
    }
}
