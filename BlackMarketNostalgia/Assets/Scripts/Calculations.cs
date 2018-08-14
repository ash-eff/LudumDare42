public class Calculations
{

    public static float AdjustedVoice(float v, float vB, float cI)
    {
        float outcome = (v + vB) / (cI + 1);
        return outcome;
    }

    public static float TimeBetweenTick(int t, int c, float p, float pB, float aV)
    {
        float outcome = ((t + 1) + (c + 1)) / ((p + pB) + aV);
        return outcome;
    }

    public static float InfluenceGainedPerSecond(float v, float vB, float p, float pB, int t, float cI)
    {
        float outcome = ((v + vB) + (p + pB)) / ((t + 1) + (cI + 1));
        return outcome;
    }

    public static float InfluenceGainedPerTick(float iG)
    {
        float outcome = (iG * 20) * (GameManager.neighborhoodsUnlocked);
        return outcome;
    }

    public static float CorporateInfluenceDecrease(float iG)
    {
        float outcome = iG;
        return outcome;
    }

    public static float ChitsEarned(float iG, float c)
    {
        float outcome = (iG / 100) * (c + 1);
        return outcome;
    }
}

