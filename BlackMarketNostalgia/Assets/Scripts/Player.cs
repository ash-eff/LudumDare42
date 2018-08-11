using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // TODO create a list to store items
    List<Upgrade> upgrades = new List<Upgrade>();

    int m_voice;
    int m_influence;
    int m_supplyQuality;

    public Player(int voice, int influence, int supplyQuality)
    {
        m_voice = voice;
        m_influence = influence;
        m_supplyQuality = supplyQuality;
    }
}
