using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    public static CardManager Instance;
    public int selectedCardIndex = -1;

    public List<int> playerOneCards = new List<int>();
    public List<int> playerTwoCards = new List<int>();
    public List<int> playerThreeCards = new List<int>();
    public List<int> playerFourCards = new List<int>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
