using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceAssiette : MonoBehaviour
{
    public GameObject MessageFin;
    public GameObject soup;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("assiette") && soup.activeSelf)
        { 
            MessageFin.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("assiette") && soup.activeSelf)
        {
            MessageFin.SetActive(true);
        }
    }
}
