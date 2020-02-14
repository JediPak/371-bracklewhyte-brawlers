using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool inWindZone = false;
    public GameObject windZone;
    public float speed = 5f;
    public float mass = 3f;
    public float size = 1;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal * speed * mass, 0.0f, moveVertical * speed * mass);
        rb.AddForce(movement);

        if (inWindZone)
        {
            rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "WindArea")
        {
            windZone = coll.gameObject;
            inWindZone = true;
        }

        if (coll.gameObject.CompareTag("Pick Up"))
        {
            coll.gameObject.SetActive(false);
            mass += 2;
            rb.mass = mass;

        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "WindArea")
        {
            inWindZone = false;
        }
    }
}
