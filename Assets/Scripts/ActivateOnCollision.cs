using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnCollision : MonoBehaviour
{

    Rigidbody rb;
    MeshCollider mc;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        this.mc = this.GetComponent<MeshCollider>();
            }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Rigidbody>().isKinematic != true)
        {
            rb.isKinematic = false;
            mc.isTrigger = false;
        }
    }
}
