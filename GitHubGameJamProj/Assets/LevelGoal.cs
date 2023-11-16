using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGoal : MonoBehaviour
{
    [SerializeField] string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Colliding!");
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Colliding With Player!");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
