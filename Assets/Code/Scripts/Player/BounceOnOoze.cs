using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOnOoze : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision) {
        //rb = collision.GetComponent<RigidBody>();
        //ContactPoint contact = collision.contacts[0];
        //collision.GetComponent<Rigidbody>();
        collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.transform.up * 10000f);
    }
}
