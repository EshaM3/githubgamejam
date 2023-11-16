using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class WindUpKey : MonoBehaviour
{
    public ThirdPersonController character;
    float rotateSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.right, (character.IsSprinting() ? 3f : 1f) * rotateSpeed * Time.deltaTime);
    }
}
