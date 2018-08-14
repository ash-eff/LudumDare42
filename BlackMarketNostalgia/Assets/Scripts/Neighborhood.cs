using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private bool hasCorpInfluence;

    GameManager gm;
    Player player;
    
    GUIManager guiManager;

    public AudioSource click;
    public TextMesh nameText;
    public TextMesh floatingText;
    public MeshRenderer mr;
    public SpriteRenderer sr;
    public SpriteRenderer outline;
    //public TextMesh lockedText;

    public Shop shop;

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
        hasCorpInfluence = true;
        nameText.text = this.name.ToString();
        isDisplayingInfo = false;
        timer = 2.5f;
        isPlayerDispensing = false;
        guiManager = FindObjectOfType<GUIManager>();
        player = FindObjectOfType<Player>();
        gm = FindObjectOfType<GameManager>();
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
            //lockedText.text = "";
            sr.enabled = false;
        }
        else
        {
            //lockedText.text = "Locked";
            sr.enabled = true;
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

            outline.enabled = true;
        }

        if (gm.GetSelectedNeighborhood() != this)
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
            m_adjustedVoice = Calculations.AdjustedVoice(player.m_voice, player.m_voiceBoost, m_corporateInfluence);
            //m_waitTime = Calculations.TimeBetweenTick((int)m_temperament, (int)m_class, player.m_persistence, player.m_persistenceBoost, m_adjustedVoice);
            m_influenceGainedPerSecond = Calculations.InfluenceGainedPerSecond(player.m_voice, player.m_voiceBoost, player.m_persistence, player.m_persistenceBoost, (int)m_temperament, m_corporateInfluence);
            print(m_influenceGainedPerSecond);
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
                if (hasCorpInfluence)
                {
                    GameManager.neighborhoodsFreed += 1;
                    hasCorpInfluence = false;
                }
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
        outline.enabled = true;

        if(!shop.shopOpen)
        {
            click.Play();
        }      
    }

    private void OnMouseExit()
    {
        onMouseOver = false;
        outline.enabled = false;
    }
}
