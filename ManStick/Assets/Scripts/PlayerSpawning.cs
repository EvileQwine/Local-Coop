using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawning : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject Player1, Player2;

    private void Awake()
    {
        Instantiate(Player1, SpawnPoints[0].position, SpawnPoints[0].rotation);
        Instantiate(Player2, SpawnPoints[1].position, SpawnPoints[1].rotation);
    }
}
