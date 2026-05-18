using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CardDisplay : MonoBehaviour
{
    public TMP_Text Title;
    public TMP_Text Description;
    public TMP_Text Stats;
    int cardNum;

    public void CreateCard(int index)
    {
        var card = CardsData.Cards[index];
        Title.text = card.title;
        Description.text = card.description;

        var s = card.stats;
        var mult = card.multiplicative;

        Stats.text =
            $"DMG: {(mult.dmg ? "*" : "+")} {s.dmg}\n" +
            $"Firerate: {(mult.firerate ? "*" : "+")} {s.firerate}\n" +
            $"Health: {(mult.health ? "*" : "+")} {s.health}\n" +
            $"Movespeed: {(mult.movespeed ? "*" : "+")} {s.movespeed}\n" +
            $"Bulletspeed: {(mult.bulletspeed ? "*" : "+")} {s.bulletspeed}";
    }

    public void Start()
    {
        cardNum = Random.Range(0, CardsData.Cards.Length);
        CreateCard(cardNum);
    }

    public void OnClick()
    {
        CardManager.Instance.selectedCardIndex = cardNum;
        SceneManager.LoadScene("CardAssign");
    }
}
