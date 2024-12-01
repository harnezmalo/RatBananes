using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class AnimPlatforme : MonoBehaviour
{
    Vector3 plateforme = new Vector3(); // Vector 3 qui contiendra l'information du mouvement � appliquer sur l'objet
    Vector3 posBas = new Vector3(0f, 0f, 0f);
    Vector3 posHaut = new Vector3(2.1f, 15.2f, 0f);
    float vitesseDep; // la vitesse du mouvement
    float deplacementDepart; // le d�placement de d�part de la plateforme
    

    void Start()
    {
        plateforme = transform.localPosition; // affectation signifiant le mouvement
        
        vitesseDep = 5f; // la vitesse du d�placement

        StartCoroutine(DepartDeplacement()); // appel de la fonction de la rotation en coroutine
    }


    /*************************************************************
    * Fonction DepartDeplacement
    * 
    *  Description:
    *       Coroutine initial qui d�marre le cycle du mouvement
    *************************************************************/
    IEnumerator DepartDeplacement()
    {
        // boucle infini afin de permettre � la plateforme de continuellement bouger
        for (; ; )
        {
            StartCoroutine(Deplacement(posBas, posHaut, vitesseDep)); // appel de la coroutine de mouvement de bas en haut
            yield return new WaitForSeconds(10f); // moment d'attente avant de d�marrer le mouvement inverse

            StartCoroutine(Deplacement(posHaut, posBas, vitesseDep)); // appel de la coroutine de mouvement de haut en bas
            yield return new WaitForSeconds(10F);
        }
    }


    /*************************************************************
    * Fonction Deplacement
    * Re�oit:
    *       debut - la position de d�part
    *       fin - la position finale
    *       duree - la dur�e en seconde du mouvement
    *  Description:
    *       Interpolation du mouvement de la plateforme
    *************************************************************/
    IEnumerator Deplacement(Vector3 debut, Vector3 fin, float duree)
    {
        // boucle d'interpolation du mouvement
        for (float t = 0; t <= 1f; t += Time.deltaTime / duree)
        {
            float valInterX = Mathf.Lerp(debut.x, fin.x, t);
            float valInterY = Mathf.Lerp(debut.y, fin.y, t);
            plateforme.y = valInterY;
            plateforme.x = valInterX;
            transform.localPosition = plateforme;
            yield return null;
        }
        
    }
}
