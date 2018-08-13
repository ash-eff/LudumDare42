using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Temperament
{
    Outraged, Apathetic, Neutral, Sypathetic, Patriotic,
}

public enum Class
{
    Poverty, LowerMiddle, Middle, UpperMiddle, Upper, Ruling,
}

public class Neighborhood : MonoBehaviour
{
    public string m_name;
    public float m_givenInfluence;
    [Range(0, 100)]
    public float m_corporateInfluence;
    public int m_population;
   
    public Temperament m_temperament;
    public Class m_class;

    public bool isUnlocked;
    public bool isPlayerDispensing;

    private float m_adjustedVoice;
    private float m_waitTime;
    public float m_influenceGainedPerSecond;
    private float m_influenceGainedPerTick;
    private float m_corporateInfluenceDecrease;

    private float m_chitsEarned;
    private float timer;

    private bool isDisplayingInfo;
    private bool onMouseOver;
    private bool isPopupTextShowing;
    public bool isShowingInfo;

    GameManager gm;
    Player player;
    SpriteRenderer sr;
    GUIManager guiManager;
    public TextMesh floatingText;
    public TextMesh nameText;
    public TextMesh lockedText;
    public MeshRenderer mr;

    private void OnEnable()
    {
        Tick.CallTick += InfluencedByPlayer;
    }

    private void OnDisable()
    {
        Tick.CallTick -= InfluencedByPlayer;
    }

    private void Start()
    {
        nameText.text = this.name.ToString();
        isDisplayingInfo = false;
        timer = 2.5f;
        isPlayerDispensing = false;
        guiManager = FindObjectOfType<GUIManager>();
        player = FindObjectOfType<Player>();
        gm = FindObjectOfType<GameManager>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(mr.enabled)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                mr.enabled = false;
                timer = 2.5f;
            }
        }

        if (isUnlocked)
        {
            lockedText.text = "";
        }
        else
        {
            lockedText.text = "Locked";
        }

        if(Input.GetMouseButtonDown(0) && onMouseOver)
        {
            isShowingInfo = true;
            gm.SetSelectedNeighborhood(this);
            guiManager.m_neighborhoodName.text = "Name: " + this.name;
            guiManager.m_population.text = "Population: " + m_population.ToString();
            guiManager.m_corporateInfluence.text = "Corporate Inf: " + System.Math.Round(m_corporateInfluence, 2).ToString();
            guiManager.m_temperament.text = "Temperament: " + m_temperament.ToString();
            guiManager.m_class.text = "Class: " + m_class.ToString();
            guiManager.m_distributing.text = "Distributing: " + isPlayerDispensing.ToString();
        }

        if(gm.GetSelectedNeighborhood() != this)
        {
            isShowingInfo = false;
        }

        if (isShowingInfo)
        {
            guiManager.m_corporateInfluence.text = "Corporate Inf: " + m_corporateInfluence.ToString();
        }
    }

    private void InfluencedByPlayer()
    {
        if (isUnlocked && isPlayerDispensing)
        {
            m_adjustedVoice = Calculations.AdjustedVoice(player.m_voice, player.m_voiceBoost, (int)m_class);
            m_waitTime = Calculations.TimeBetweenTick((int)m_temperament, (int)m_class, player.m_persistence, player.m_persistenceBoost, m_adjustedVoice);
            m_influenceGainedPerSecond = Calculations.InfluenceGainedPerSecond(player.m_voice, player.m_voiceBoost, player.m_persistence, player.m_persistenceBoost, (int)m_temperament, (int)m_class);
            m_influenceGainedPerTick = Calculations.InfluenceGainedPerTick(m_influenceGainedPerSecond);
            m_corporateInfluenceDecrease = Calculations.CorporateInfluenceDecrease(m_influenceGainedPerSecond);
            m_chitsEarned = Calculations.ChitsEarned(m_influenceGainedPerSecond, (int)m_class);
            mr.enabled = true;
            floatingText.text = "+" + System.Math.Round(m_influenceGainedPerTick, 2).ToString();
            player.m_influence += m_influenceGainedPerTick;
            player.m_chits += m_chitsEarned;
            if((m_corporateInfluence - m_corporateInfluenceDecrease) <= 0)
            {
                m_corporateInfluence = 0;
            }
            else
            {
                m_corporateInfluence -= m_corporateInfluenceDecrease;
            }
        }
    }

    private void OnMouseEnter()
    {
        onMouseOver = true;
    }

    private void OnMouseExit()
    {
        onMouseOver = false;
    }
}
