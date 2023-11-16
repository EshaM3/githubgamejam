using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public bool stopCreator = false;
    public Saxophone assignedSaxophone;
    public Collider[] colliders;
    public GameObject raspberryParent;
    private Animator anim;
    private bool startedEating = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
            if (stopCreator){
                other.GetComponent<RaspberryBounce>().creator.bearIsPresent = true;
            } else if (assignedSaxophone != null){
                assignedSaxophone.bearIsPresent = true;
            }
            if (!startedEating){
                startedEating = true;
                StartCoroutine(eating());
            }
        }
    }
    IEnumerator eating()
    {
        foreach (Collider col in colliders){
            col.enabled = false;
        }
        raspberryParent.SetActive(true);
        anim.SetTrigger("Berry");

        yield return new WaitForSeconds(1.5f);

        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().velocity = Vector3.up*4f;

        yield return new WaitForSeconds(2.5f);

        Destroy(this.gameObject);
    }
}
