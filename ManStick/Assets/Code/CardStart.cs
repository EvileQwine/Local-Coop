using UnityEngine;

public class CardStart : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform canvas;
    [SerializeField] public int numCards = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < numCards; i++)
        {
            GameObject cardObj = Instantiate(cardPrefab, canvas.position + new Vector3(5 * i, 0, 0), Quaternion.identity, canvas);

            
        }
    }
}
