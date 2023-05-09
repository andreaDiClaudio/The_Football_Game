using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePlayer : MonoBehaviour
{
    public List<Player> players = new List<Player>();
    public int playerIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        Player[] playerGameObjects = FindObjectsOfType<Player>();
        Debug.Log(playerGameObjects);
        playerGameObjects[1].enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            DeactivatePlayer(playerIndex);
            playerIndex++;

            if (playerIndex >= players.Count)
            {
                playerIndex = 0;
            }

            ActivatePlayer(playerIndex);
        }
    }

    private void DeactivatePlayer(int index)
    {
        players[index].enabled = false;
    }

    private void ActivatePlayer(int index)
    {
        players[index].enabled = true;
    }
}
