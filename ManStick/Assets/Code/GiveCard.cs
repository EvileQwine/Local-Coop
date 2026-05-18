using UnityEngine;

public class GiveCard : MonoBehaviour
{
    int cardIndex = CardManager.Instance.selectedCardIndex;

    public void GiveCardToPlayer()
    {
        switch (gameObject.name)
        {
            case "first":
                CardManager.Instance.playerOneCards.Add(cardIndex);
                break;
            case "second":
                CardManager.Instance.playerTwoCards.Add(cardIndex);
                break;
            case "third":
                CardManager.Instance.playerThreeCards.Add(cardIndex);
                break;
            case "fourth":
                CardManager.Instance.playerFourCards.Add(cardIndex);
                break;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
