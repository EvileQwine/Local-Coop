using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawning : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject Player1, Player2;

    private void Awake()
    {

    }
    public void OnJoinCtr()
    {
        Debug.Log("Ctr");
        Instantiate(Player1, SpawnPoints[0].position, new Quaternion(0, 0, 0, 0));
    }
    public void OnJoinKey()
    {
        Debug.Log("Key");
        Instantiate(Player2, SpawnPoints[1].position, new Quaternion(0,0,0,0));
    }

}
