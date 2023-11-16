using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaspberryBounce : MonoBehaviour
{
    public float Gravity = -15.0f;
    public float lifeTimer = 5f;
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
            float TimpaniLaunchHeight = collision.transform.parent.gameObject.GetComponent<Timpani>().timpaniForce;
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(TimpaniLaunchHeight * -2f * Gravity), rb.velocity.z);
        } else {
            rb.velocity *= 0.15f;
        }
    }
}
