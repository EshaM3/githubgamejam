using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public Saxophone assignedSaxophone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if (other.gameObject.CompareTag("Raspberry"))
        {
            Debug.Log("rasp");
            assignedSaxophone.bearIsPresent = true;
            gameObject.SetActive(false);
        }
    }
}
