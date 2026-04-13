using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawning : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject Player1, Player2;
    bool spawnedCtr = false;
    bool spawnedKey = false;
    PlayerInput pi;
    private void Awake()
    {
        pi = GetComponent<PlayerInput>();
    }
    public void OnJoinCtr()
    {
        if (!spawnedCtr)
        {
            spawnedCtr = true;
            Instantiate(Player1, SpawnPoints[0].position, new Quaternion(0, 0, 0, 0));
            pi.actions.FindAction("JoinCtr").Disable();
        } 
    }
    public void OnJoinKey()
    {
        if (!spawnedKey)
        {
            spawnedKey = true;
            Instantiate(Player2, SpawnPoints[1].position, new Quaternion(0, 0, 0, 0));
            pi.actions.FindAction("JoinKey").Disable();
        }       
    }
}
