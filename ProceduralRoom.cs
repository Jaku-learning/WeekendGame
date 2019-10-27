using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProceduralRoom : MonoBehaviour
{
    public int openingDirection;
    // 1 bottom
    // 2 top
    // 3 left
    // 4 right

    private RoomTemplates roomTemplates;
    private int randomCalc;
    private bool spawned = false;

    private void Start()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("rooms").GetComponent<RoomTemplates>();
        Invoke("CheckOpeningDirection", 0.1f);
    }

    void CheckOpeningDirection()
    {
        if (!spawned)
        {
            if (openingDirection == 1)
            {
                randomCalc = Random.Range(0, roomTemplates.bottomRooms.Length);
                Instantiate(roomTemplates.bottomRooms[randomCalc], transform.position, Quaternion.identity);
            }

            else if (openingDirection == 2)
            {
                randomCalc = Random.Range(0, roomTemplates.topRooms.Length);
                Instantiate(roomTemplates.topRooms[randomCalc], transform.position, Quaternion.identity);
            }

            else if (openingDirection == 3)
            {
                randomCalc = Random.Range(0, roomTemplates.leftRooms.Length);
                Instantiate(roomTemplates.leftRooms[randomCalc], transform.position, Quaternion.identity);
            }

            else if (openingDirection == 4)
            {
                randomCalc = Random.Range(0, roomTemplates.rightRooms.Length);
                Instantiate(roomTemplates.rightRooms[randomCalc], transform.position, Quaternion.identity);
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint") && other.GetComponent<ProceduralRoom>().spawned == true)
        {
            Destroy(gameObject);
        }
    }
}