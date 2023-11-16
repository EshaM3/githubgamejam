using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saxophone : MonoBehaviour
{
    public GameObject raspberry;
    public Transform launchPoint;
    [SerializeField] float RaspberryLaunchHeight;
    public bool bearIsPresent;

    public Material[] saxophoneMats;
    public Material[] currentSaxophoneMats;
    public GameObject containedMusicNote;
    public int containedMusicNoteValue = 0;
    float yRot;
    float zRot;

    // Start is called before the first frame update
    void Start()
    {
        currentSaxophoneMats = GetComponent<SkinnedMeshRenderer>().materials;
        StartCoroutine(spacedOut());
        yRot = transform.localEulerAngles.y;
        zRot = transform.localEulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        /*gameObject.transform.localEulerAngles = new Vector3(-100 + (10 * containedMusicNoteValue),
            gameObject.transform.localEulerAngles.y,
            gameObject.transform.localEulerAngles.z);*/

        transform.localRotation = Quaternion.Euler(-30 + (-12 * containedMusicNoteValue), yRot, zRot);

        //saxophone color changes based on note
        currentSaxophoneMats[1] = saxophoneMats[containedMusicNoteValue];
        GetComponent<SkinnedMeshRenderer>().materials = currentSaxophoneMats;
    }
    IEnumerator spacedOut()
    {
        yield return new WaitForSeconds(2);
        var rasp = Instantiate(raspberry, launchPoint.position, raspberry.transform.rotation);
        /*rasp.gameObject.GetComponent<Rigidbody>().velocity = rasp.gameObject.GetComponent<Rigidbody>().velocity +
            transform.forward*RaspberryLaunchHeight*.5f - transform.right*RaspberryLaunchHeight*3;*/
        rasp.gameObject.GetComponent<Rigidbody>().velocity = launchPoint.transform.forward*RaspberryLaunchHeight*1.5f;
        rasp.GetComponent<RaspberryBounce>().creator = this;
        if (bearIsPresent == false)
        {
            StartCoroutine(spacedOut());
        }
    }

    public void PopOutAndStore(int newNote)
    {
        /*if (containedMusicNoteValue != -1)
        {
            var poppedOutMusicNote = Instantiate(containedMusicNote);
            poppedOutMusicNote.transform.position = transform.position + (transform.right * 2) + transform.forward;
            poppedOutMusicNote.GetComponent<MusicNote>().changeNote(containedMusicNoteValue);
        }*/
        containedMusicNoteValue = newNote;
    }
}
