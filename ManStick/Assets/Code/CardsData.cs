using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CardsData : MonoBehaviour
{
    public static (string title, string description, (float dmg, float firerate, float health, float movespeed, float bulletspeed) stats, (bool dmg, bool firerate, bool health, bool movespeed, bool bulletspeed) multiplicative)[] Cards = new (string, string, (float, float, float, float, float), (bool, bool, bool, bool, bool))[]
    {
        ("Spray'n'pray", "heavy gatling gun massively increased firerate but much less movement speed", (0.5f, 0.1f, 1f, 0.75f, 2f), (true, true, true, true, false)),
        ("chaos incarnate", "nggyunglydngraady", (100f, 0.01f, 100f, 3f, 5f), (true, true, true, true, true))
    };
}
