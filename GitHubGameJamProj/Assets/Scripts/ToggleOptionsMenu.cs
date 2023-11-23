using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOptionsMenu : MonoBehaviour
{
    public GameObject menuToggle;
    public void ToggleMenu(){
        menuToggle.SetActive(!menuToggle.activeInHierarchy);
    }
}
