using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraController : MonoBehaviour
{
    public GameObject player, cameraArm, cameraObj, highPoint, lowPoint;
    public float orbit, tilt, zoom, followSpeed, centerInfluence, orbitSpeed, tiltSpeed, zoomSpeed;
    public Volume dofVolume;

    [SerializeField]
    private InputActionReference lookRef, scrollRef;
    // Start is called before the first frame update
    void Start()
    {
        ShiftPosition(cameraObj.transform.localPosition.z, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        ControlCamera();
        UpdateCamera();
        ModifyDepthOfField();
    }

    public void ControlCamera(){
        float z = scrollRef.action.ReadValue<float>();
        if (z > 0){
            zoom += zoomSpeed;
        } else if (z < 0){
            zoom -= zoomSpeed;
        }

        orbit += lookRef.action.ReadValue<Vector2>().x*orbitSpeed;

        tilt += lookRef.action.ReadValue<Vector2>().y*tiltSpeed;
    }

    public void UpdateCamera(){
        
        transform.rotation = Quaternion.Euler(0f, orbit, 0f);

        tilt = Mathf.Clamp(tilt,-90f, 90f);
        cameraArm.transform.localRotation = Quaternion.Euler(tilt, 0f, 0f);
        float tiltPercent = (tilt+90f)/180f;
        cameraArm.transform.position = lowPoint.transform.position + (highPoint.transform.position-lowPoint.transform.position)*tiltPercent;

        zoom = Mathf.Clamp(zoom, -10f, -1f);
        float zPos = zoom*(tiltPercent*1.5f);
        cameraObj.transform.localPosition = new Vector3(0f, 0f, zPos);

        ShiftPosition(zPos, followSpeed);
    }

    void ShiftPosition (float zPos, float follow){
        if (player != null){
            float centerInMod = centerInfluence*zPos/-10f;

            Vector3 playerPos = player.transform.position;
            Vector3 centerPos = new Vector3(0f, playerPos.y, 0f);
            Vector3 pivot = playerPos + (centerPos-playerPos)*centerInMod;
            if ((pivot-transform.position).magnitude < follow){
                transform.position = pivot;
            } else {
                transform.position += (pivot-transform.position).normalized*follow;
            }
        }
    }

    void ModifyDepthOfField(){
        if (dofVolume != null){
            float cameraDist = (transform.position-cameraObj.transform.position).magnitude;
            VolumeProfile profile = dofVolume.sharedProfile;
            if (profile.TryGet<DepthOfField>(out var dof)){
                float myFocalDist = cameraDist*0.4938f + 0.1111f;
                dof.focusDistance.value = myFocalDist;
                dof.focusDistance.overrideState = true;

                float myFocalLength = cameraDist*5.3704f + 43.3333f;
                dof.focalLength.value = myFocalLength;
                dof.focalLength.overrideState = true;
            }
            //Debug.Log(cameraDist);
        }
    }
}