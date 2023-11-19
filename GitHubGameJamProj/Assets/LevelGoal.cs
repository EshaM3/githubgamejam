using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGoal : MonoBehaviour
{
    [SerializeField] string nextSceneName;
    float rotateSpeed = -20f;
    private Animator anim;
    private bool startedWinning = false;

    void Start(){
        anim = GetComponent<Animator>();
        nextSceneName = FindObjectOfType<LevelOrder>().nextLevel(SceneManager.GetActiveScene().name);
    }

    void Update(){
        transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        if (startedWinning){
            rotateSpeed -= 10f*Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Colliding!");
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Colliding With Player!");
            if (!startedWinning){
                startedWinning = true;
                StartCoroutine(levelComplete());
            }
        }
    }
    IEnumerator levelComplete()
    {
        anim.SetTrigger("Win");
        GetComponent<AudioSource>().volume = MusicPlayer.SFX_Volume;
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(4.5f);

        SceneManager.LoadScene(nextSceneName);
    }
}
