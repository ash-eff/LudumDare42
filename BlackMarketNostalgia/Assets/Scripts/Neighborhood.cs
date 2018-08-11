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

    [SerializeField] string m_name;
    [SerializeField] int m_population;
    [Range(0,100)]
    [SerializeField] int m_corporateInfluence;
    [SerializeField] Temperament m_temperament;
    [SerializeField] Income m_income;

    private GUIStyle guiStyleBox;
    private string text;
    private string currentToolTipText = "";

    private void Start()
    {
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

    private void OnMouseEnter()
    {
        currentToolTipText = text;
    }

    private void OnMouseExit()
    {
        currentToolTipText = "";
    }

}
