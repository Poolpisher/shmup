using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    TextMeshProUGUI txt;
    public static int score;
    
    // Start is called before the first frame update
    void Start()
    {
        //Récupère le texte du HUD
        txt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //Mise à jour du score dans le HUD
        txt.text = "" + score;
    }
}
