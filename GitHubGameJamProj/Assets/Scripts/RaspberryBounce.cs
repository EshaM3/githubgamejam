using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaspberryBounce : MonoBehaviour
{
    public float Gravity = -15.0f;
    public float lifeTimer = 5f;
    public Saxophone creator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f){
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
            Rigidbody rb = GetComponent<Rigidbody>();
        if (collision.gameObject.CompareTag("TimpaniSurface"))
        {
            float TimpaniLaunchHeight = collision.transform.parent.gameObject.GetComponent<Timpani>().StartBounce();
            rb.velocity = new Vector3(rb.velocity.x, TimpaniLaunchHeight, rb.velocity.z);
            //collision.transform.parent.gameObject.GetComponent<Timpani>().PlaySfx();
        } else if (collision.gameObject.CompareTag("HarpBounce"))
        {
            rb.velocity = collision.transform.parent.gameObject.GetComponent<Harp>().StartBounce(collision.transform.up);
            //collision.transform.parent.gameObject.GetComponent<Timpani>().PlaySfx();
        }else {
            //rb.velocity *= 0.15f;
        }
    }
}
