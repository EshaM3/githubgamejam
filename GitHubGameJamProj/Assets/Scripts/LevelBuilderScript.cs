using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using Unity.VisualScripting;
using StarterAssets;
using Cinemachine;

public class LevelBuilderScript : MonoBehaviour
{
    public int selectedMusicBox = 0;
    public GameObject[] musicBoxPrefabs;
    public GameObject[] essentialPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnMusicBox(){
        foreach (Transform child in transform) {
            GameObject.DestroyImmediate(child.gameObject);
        }

        if (selectedMusicBox < musicBoxPrefabs.Length){
            GameObject go = Instantiate<GameObject>(musicBoxPrefabs[selectedMusicBox], this.transform);
            go.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    public void SnapObjects(){
        Snappable[] toSnap = FindObjectsOfType<Snappable>();

        foreach (Snappable snap in toSnap){
            if (snap.snapPosition){
                float roundedX = RoundTo(snap.transform.position.x, 0.5f);
                float roundedY = RoundTo(snap.transform.position.y, 0.5f);
                float roundedZ = RoundTo(snap.transform.position.z, 0.5f);

                snap.transform.position = new Vector3(roundedX, roundedY, roundedZ);
            }
            if (snap.snapRotation){
                float xRot = RoundTo(snap.transform.eulerAngles.x, 45f);
                float yRot = RoundTo(snap.transform.eulerAngles.y, 45f);
                float zRot = RoundTo(snap.transform.eulerAngles.z, 45f);

                snap.transform.eulerAngles = new Vector3(xRot, yRot, zRot);
            }
        }
    }

    public void SpawnEssentials(){
        if (FindObjectOfType<ThirdPersonController>() == null){
            foreach (GameObject go in essentialPrefabs){
                Instantiate(go);
            }
        }
        CinemachineVirtualCamera cvc = FindObjectOfType<CinemachineVirtualCamera>();
        GameObject followObject = FindObjectOfType<ThirdPersonController>().transform.Find("PlayerCameraRoot").gameObject;
        cvc.Follow = followObject.transform;
    }

    static float RoundTo(float value, float multipleOf) {
        return Mathf.Round(value/multipleOf) * multipleOf;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
