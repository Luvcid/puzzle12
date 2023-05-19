using UnityEngine;

public class MonsterSummoner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public GameObject monster2Prefab;
    public GameObject player;

    private GameObject currentMonster;
    private bool isControllingMonster;
    private bool isMonster2Active = false;

    void Start()
    {
        isControllingMonster = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            

            if (!isControllingMonster)
            {
                player.GetComponent<PlayerScript>().enabled = false;
                if (currentMonster != null)
                {
                    currentMonster.SetActive(false);
                }
                currentMonster = Instantiate(monsterPrefab, transform.position, Quaternion.identity);
                isControllingMonster = true;
                GetComponent<Rigidbody2D>().isKinematic = true;
                Camera.main.GetComponent<camerafollow>().target = currentMonster.transform;
            }
        }

        else if (Input.GetKeyDown(KeyCode.R))
                {
                    player.GetComponent<PlayerScript>().enabled = false;
                    if (isControllingMonster)
                    {
                        if (currentMonster.GetComponent<MonsterController>().isGrabbing)
                        {
                            currentMonster.GetComponent<MonsterController>().ReleaseObject();
                        }
                        currentMonster.SetActive(false);
                        if (isMonster2Active)
                        {
                            currentMonster = Instantiate(monsterPrefab, transform.position, Quaternion.identity);
                            isMonster2Active = false;
                        }
                        else
                        {
                            currentMonster = Instantiate(monster2Prefab, transform.position, Quaternion.identity);
                            isMonster2Active = true;
                        }
                        isControllingMonster = true;
                        Camera.main.GetComponent<camerafollow>().target = currentMonster.transform;
                    }
                }
        
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isControllingMonster)
            {
                Destroy(currentMonster);
                isControllingMonster = false;
                GetComponent<Rigidbody2D>().isKinematic = false;
                player.GetComponent<PlayerScript>().enabled = true;
                Camera.main.GetComponent<camerafollow>().target = transform;
            }
        }
    }
}

/*
else if (Input.GetKeyDown(KeyCode.R))
        {
            player.GetComponent<PlayerScript>().enabled = false;
            if (isControllingMonster)
            {
                currentMonster.SetActive(false);
                currentMonster.GetComponent<MonsterController>().ReleaseObject();
                if (isMonster2Active)
                {
                    currentMonster = Instantiate(monsterPrefab, transform.position, Quaternion.identity);
                    isMonster2Active = false;
                }
                else
                {
                    currentMonster = Instantiate(monster2Prefab, transform.position, Quaternion.identity);
                    isMonster2Active = true;
                }
                isControllingMonster = true;
                Camera.main.GetComponent<camerafollow>().target = currentMonster.transform;
            }
        }
*/
