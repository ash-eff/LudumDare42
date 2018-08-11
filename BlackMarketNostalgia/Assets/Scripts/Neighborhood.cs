public enum Temperament
{
    Outraged, Apathetic, Neutral, Sypathetic, Patriotic,
}

public enum Income
{
    Poverty, LowerMiddle, Middle, UpperMiddle, Upper, Ruling,
}

public class Neighborhood
{

    private string m_name;
    private int m_population;
    private int m_corporateInfluence;
    private Temperament m_temperament;
    private Income m_income;

    public void NeighborhoodSetUp(string name, int population, int corporateInfluence, Temperament temperament, Income income)
    {
        m_name = name;
        m_population = population;
        m_corporateInfluence = corporateInfluence;
        m_temperament = temperament;
        m_income = income;
    } 

    public int CorporateInfluence
    {
        get { return m_corporateInfluence; }
        set { m_corporateInfluence -= value; }
    }
}
