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
    public Sprite unlock, locked;

    public float availableInfluence;
    public float givenInfluence;
    public string m_name;
    public int m_population;
    [Range(0,100)]
    public float m_corporateInfluence;
    public Temperament m_temperament;
    public Class m_class;

    private string text;
    private string currentToolTipText = "";
    private float waitTime;
    private bool isDeductingInfluence;
    public bool isUnlocked;

    GameManager gm;
    Player player;
    SpriteRenderer sr;

    public Class GetClass() { return m_class; }
    public Temperament GetTemperament() { return m_temperament; }
    public void SetTime(float time) { waitTime = time; }
    public void SetIsDeductingInfluence(bool b) { isDeductingInfluence = b; }
    public bool GetIsDeductingInfluence() { return isDeductingInfluence; }

    private void Start()
    {
        isDeductingInfluence = false;
        player = FindObjectOfType<Player>();
        gm = FindObjectOfType<GameManager>();
        sr = GetComponent<SpriteRenderer>();
        FormatText();
        CalculateAvailableInfluence();
    }

    private void Update()
    {
        if(isUnlocked)
        {
            sr.sprite = unlock;
        }
        else
        {
            sr.sprite = locked;
        }
    }

    public IEnumerator DeductInfluence()
    {
        while(isDeductingInfluence && availableInfluence > givenInfluence)
        {
            givenInfluence += 20f;
            player.m_influence += 20f;

            yield return new WaitForSeconds(waitTime);
        }
    }

    public void CalculateAvailableInfluence()
    {
        availableInfluence = m_population - (m_population * (m_corporateInfluence / 100));
    }

    private void FormatText()
    {
        text = "\nName: " + m_name + "\n"
            + "Population: " + m_population + "\n"
            + "Corporate Influence: " + m_corporateInfluence.ToString() + "\n"
            + "Temperament: " + m_temperament.ToString() + "\n"
            + "Income: " + m_class.ToString();
    }

    private void OnGUI()
    {
        if (currentToolTipText != "")
        {
            // follow mouse pos
            float x = Event.current.mousePosition.x;
            float y = Event.current.mousePosition.y;
            GUI.Box(new Rect(x + 10, y + 10, 300, 110), currentToolTipText);
        }
    }

    private void OnMouseDown()
    {
        if(!isUnlocked && player.m_influence > gm.amountToUnlockNextNeighborhood)
        {
            isUnlocked = true;
            gm.IncreaseUnlockCost();
        }

        if (isUnlocked)
        {
            gm.SetSelectedNeighborhood(this);
        }
    }

    private void OnMouseEnter()
    {
        currentToolTipText = text;
    }

    private void OnMouseExit()
    {
        currentToolTipText = "";
    }

}
