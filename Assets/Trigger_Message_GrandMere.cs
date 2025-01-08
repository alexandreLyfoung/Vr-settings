using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Message_GrandMere : MonoBehaviour
{
    public GameObject MessageGrandMere;
    // Start is called before the first frame update
    void Start()
    {
        MessageGrandMere.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MessageGrandMere.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MessageGrandMere.SetActive(false);
        }
    }
}
