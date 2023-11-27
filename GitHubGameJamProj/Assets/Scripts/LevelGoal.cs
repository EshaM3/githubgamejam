using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class LevelGoal : MonoBehaviour
{
    [SerializeField] string nextSceneName;
    float rotateSpeed = -20f;
    private Animator anim;
    private bool startedWinning = false;
    private PlayerInput playerInput;
    private bool shouldCollectCoin = false;

    void Start(){
        anim = GetComponent<Animator>();
        LevelOrder levelOrder = FindObjectOfType<LevelOrder>();
        if (levelOrder != null){
            nextSceneName = levelOrder.nextLevel(SceneManager.GetActiveScene().name);
        }
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
                playerInput = other.gameObject.GetComponent<PlayerInput>();
                startedWinning = true;
                StartCoroutine(levelComplete());
            }
        }
    }
    IEnumerator levelComplete()
    {
        playerInput.DeactivateInput();
        anim.SetTrigger("Win");
        GetComponent<AudioSource>().volume = MusicPlayer.SFX_Volume;
        GetComponent<AudioSource>().Play();
        if (shouldCollectCoin){
            LevelOrder levelOrder = FindObjectOfType<LevelOrder>();
            if (levelOrder != null){
                levelOrder.SetCollectedCoin();
            }
        }

        yield return new WaitForSecondsRealtime(2.5f);

        playerInput.ActivateInput();
        SceneManager.LoadScene(nextSceneName);
    }
    public void CollectCoin(){
        shouldCollectCoin = true;
    }
}
