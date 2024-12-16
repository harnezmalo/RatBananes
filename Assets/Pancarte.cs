using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pancarte : MonoBehaviour
{
    public Canvas canvas;
    public string Texte;
    public TMPro.TMP_Text Text_zone;
    bool wait = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (Input.GetKey(KeyCode.Space) && canvas.enabled == false && wait == false)
            {
                Debug.Log("dsgfew");
                canvas.enabled = true;
                Text_zone.text = Texte;
            }

            if (Input.GetKey(KeyCode.Space) && canvas.enabled == true && wait == false)
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

    IEnumerator 
}
