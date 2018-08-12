using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // TODO create a list to store items
    List<Upgrade> upgrades = new List<Upgrade>();

    // currency
    public float m_influence = 0;

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
}
