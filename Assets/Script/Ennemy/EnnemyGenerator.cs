using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EnnemyGenerator : MonoBehaviour
{
    //Determine le nombres de vagues
    [SerializeField] private Wave[] waves;
    //Numéro de la vague
    private int waveNumber;
    //Event unity en cas de réussite
    [SerializeField] private UnityEvent onFinishingAllWaves;


    /// <summary>
    /// Vérifie que les cases nombreEnnemy et typeEnnemy du tableau sont de même taille
    /// Et que le temps d'antebellum, la musique et le spawn est bien égal à 1
    /// </summary>
    void OnValidate()
    {
        foreach(var wave in waves)
        {
            if (wave.time.Length != wave.ennemies.Length -1)
            {
                //Changement des tableaux
                System.Array.Resize(ref wave.time, Mathf.Clamp(wave.ennemies.Length - 1, 0, int.MaxValue));
            }
            if (wave.spawn.Length != wave.ennemies.Length)
            {
                //Changement des tableaux
                System.Array.Resize(ref wave.spawn, wave.ennemies.Length);
            }
        }
    }

    void Start()
    {
        LaunchWave();
    }
    
    /// <summary>
    /// Instantie les ennemies d'une vague avant de passer à la suivante
    /// </summary>
    public void LaunchWave()
    {
        StartCoroutine(WaitForNextEnnemy());
    }

    //Temps d'attente entre chaque ennemis
    public IEnumerator WaitForNextEnnemy()
    {
        for (var i=0; i<waves[waveNumber].ennemies.Length; i++)
        {
            var ennemy = waves[waveNumber].ennemies[i];
            //Créer les ennemies à la position du générateur d'ennemie
            GameObject createEnnemies = Instantiate(ennemy, waves[waveNumber].spawn[i].transform.position, Quaternion.identity);
            if (i == waves[waveNumber].ennemies.Length - 1)
            {
                //Tout les ennemies de la vague sont apparues
                //Lance l'écran de victoire
                onFinishingAllWaves.Invoke();
                yield break;
            }
            //attente jusqu'au prochain ennemie
            yield return new WaitForSeconds(waves[waveNumber].time[i]);
        }
    }
}
