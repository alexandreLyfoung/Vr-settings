using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceMarmitte : MonoBehaviour
{
    public GameObject marmitte;
    private Rigidbody rb;
    private int nbAliment = 0;
    private bool marmitteIsSet = false;
    private bool marmitteAttendsAssiette = false;
    private AudioSource marmiteCuisson;
    public GameObject MessageAssiette;
    public GameObject Soup;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = marmitte.GetComponent<Rigidbody>();
        marmiteCuisson = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Marmitte")) {
            other.gameObject.transform.position = gameObject.transform.position;
            rb.rotation = Quaternion.identity;
            rb.isKinematic = false;
            rb.freezeRotation = true;
            rb.velocity = Vector3.zero;
        }
        if (other.gameObject.CompareTag("aliment") && marmitteIsSet)
        {
            nbAliment++;
            Destroy(other.gameObject);
            if (nbAliment == 3)
            {
                marmiteCuisson.loop = true;
                marmiteCuisson.Play();
                MessageAssiette.SetActive(true);
                marmitteAttendsAssiette = true;
            }
           
        }
        if (other.gameObject.CompareTag("assiette") && marmitteAttendsAssiette)
        {
            Soup.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Marmitte"))
        {
            other.gameObject.transform.position = gameObject.transform.position;
            rb.rotation = Quaternion.identity;
            rb.isKinematic = false;
            rb.freezeRotation = true;
            rb.velocity = Vector3.zero;
            marmitteIsSet = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Marmitte"))
        {
            collision.gameObject.transform.position = gameObject.transform.position;
            rb.rotation = Quaternion.identity;
            rb.isKinematic = false;
            rb.freezeRotation = true;
            rb.velocity = Vector3.zero;
            marmitteIsSet = true;
        }
        if (collision.gameObject.CompareTag("aliment") && marmitteIsSet)
        {
            nbAliment++;
            Destroy(collision.gameObject);
            if (nbAliment == 3)
            {
                marmiteCuisson.loop = true;
                marmiteCuisson.Play();
                MessageAssiette.SetActive(true);
                marmitteAttendsAssiette = true;
            }
        }
        if (collision.gameObject.CompareTag("assiette") && marmitteAttendsAssiette)
        {
            Soup.SetActive(true);
        }
    }
}
