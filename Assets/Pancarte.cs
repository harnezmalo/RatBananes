using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pancarte : MonoBehaviour
{
    public Canvas canvas;
    public string Texte;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Space) && canvas.enabled == false)
            {
                canvas.enabled = true;
                Text texte = canvas.GetComponentInChildren<Text>();
                texte.text = Texte;
            }

            if (Input.GetKey(KeyCode.Space) && canvas.enabled == true)
            {
                canvas.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.enabled = false;
        }
    }
}
