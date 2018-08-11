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
    public float availableInfluence;
    public string m_name;
    public int m_population;
    [Range(0,100)]
    public float m_corporateInfluence;
    public Temperament m_temperament;
    public Class m_class;

    private GUIStyle guiStyleBox;
    private string text;
    private string currentToolTipText = "";
    private float waitTime;

    GameManager gm;

    public Class GetClass() { return m_class; }
    public Temperament GetTemperament() { return m_temperament; }
    public void SetTime(float time) { waitTime = time; }
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        // TODO use to customize GUI later
        guiStyleBox = new GUIStyle();
        FormatText();
    }

    private void Update()
    {
        CalculateAvailableInfluence();
    }

    public IEnumerator DeductInfluence()
    {
        while(availableInfluence > 0)
        {
            availableInfluence -= 20;

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
        gm.SetSelectedNeighborhood(this);
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
