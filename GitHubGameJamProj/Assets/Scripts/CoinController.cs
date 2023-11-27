using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int currentCoinIndex;
    public GameObject[] coinPrefabs;
    LevelOrder levelOrder;
    float rotateSpeed = -15f;
    float verticalSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        levelOrder = FindObjectOfType<LevelOrder>();
        if (levelOrder != null){
            bool collectedAlready = levelOrder.CollectedCoin();
            if (collectedAlready && currentCoinIndex < 4){
                GameObject go = Instantiate<GameObject>(coinPrefabs[4]);
                go.transform.position = transform.position;
                Destroy(this.gameObject);
            } else if (!collectedAlready) {
                int difficulty = levelOrder.GetCoinDifficulty();
                if (difficulty != currentCoinIndex){
                    transform.position += Vector3.up*(difficulty%2)*0.25f;
                    GameObject go = Instantiate<GameObject>(coinPrefabs[difficulty]);
                    go.transform.position = transform.position;
                    Destroy(this.gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        transform.position += Vector3.up*verticalSpeed*Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Raspberry") || other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(despawning());
        }
    }
    IEnumerator despawning()
    {
        Destroy(GetComponent<Collider>());
        FindObjectOfType<LevelGoal>().CollectCoin();
        
        verticalSpeed = 2f;

        GetComponent<AudioSource>().volume = MusicPlayer.SFX_Volume;
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(5f);

        Destroy(this.gameObject);
    }
}
