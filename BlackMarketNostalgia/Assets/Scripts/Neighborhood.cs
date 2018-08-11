using UnityEngine;

public enum Temperament
{
    Outraged, Apathetic, Neutral, Sypathetic, Patriotic,
}

public enum Income
{
    Poverty, LowerMiddle, Middle, UpperMiddle, Upper, Ruling,
}

public class Neighborhood : MonoBehaviour
{

    public string m_name;
    public int m_population;
    [Range(0,100)]
    public int m_corporateInfluence;
    public Temperament m_temperament;
    public Income m_income;

    private GUIStyle guiStyleBox;
    private string text;
    private string currentToolTipText = "";

    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        // TODO use to customize GUI later
        guiStyleBox = new GUIStyle();
        FormatText();
    }

    private void FormatText()
    {
        text = "\nName: " + m_name + "\n"
            + "Population: " + m_population + "\n"
            + "Corporate Influence: " + m_corporateInfluence.ToString() + "\n"
            + "Temperament: " + m_temperament.ToString() + "\n"
            + "Income: " + m_income.ToString();
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
