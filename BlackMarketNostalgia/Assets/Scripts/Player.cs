using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // currency
    public float m_influence = 0;
    public float m_chits = 0;
    public string m_title;

    // the ability to battle against the class of the neighborhood. Having more boosts players persistence
    // formula is Voice / Class = Adjusted Voice
    public float m_voice;
    public float m_voiceBoost;
    public float m_adjustedVoice;

    // the ability to resist against the class of a neighborhood. Having more reduces the time between ticks of influence
    // formula is Temperament + Class / Persistence + Persistence Boost + Adjusted Voice = Time Between Tick
    public float m_persistence;
    public float m_persistenceBoost;

    public float GetAdjustedVoice() { return m_adjustedVoice; }
    public void SetAdjustedVoice(float adjustedVoice) { m_adjustedVoice = adjustedVoice; }

    public float GetVoice() { return m_voice; }
    public float GetVoiceBoost() { return m_voiceBoost; }
    public float GetPersistence() { return m_persistence; }
    public float GetPersistenceBoost() { return m_persistenceBoost; }

    private void Update()
    {
        int switchCase = (int)m_influence / 4000;
        switch(switchCase)
        {
            case 1:
                m_title = "Known";
                break;

            case 2:
                m_title = "Extra Known";
                break;

            default:
                m_title = "Unknown";
                break;
        }

    }
}
