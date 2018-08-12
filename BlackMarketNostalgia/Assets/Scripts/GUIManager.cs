using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    public Text m_neighborhoodName;
    public Text m_population;
    public Text m_corporateInfluence;
    public Text m_temperament;
    public Text m_class;
    public Text m_distributing;

    public Text m_playerInfo;
    public Text m_influence;
    public Text m_voice;
    public Text m_persistence;
    public Text m_chits;
    public Text m_nextUnlock;

    GameManager gm;
    Player player;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        m_playerInfo.text = "Title: " + player.m_title;
        m_influence.text = "Influence: " + Mathf.RoundToInt(player.m_influence).ToString();
        m_voice.text = "Voice: " + System.Math.Round(player.m_voice + player.m_voiceBoost, 2);
        m_persistence.text = "Persistence: " + System.Math.Round(player.m_persistence + player.m_persistenceBoost, 2);
        m_chits.text = "Chits: " + System.Math.Round(player.m_chits, 2).ToString();
        m_nextUnlock.text = "Next Unlock: " + gm.amountToUnlockNextNeighborhood.ToString();
    }
}
