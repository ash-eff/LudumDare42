public class Calculations
{

    public static float AdjustedVoice(float v, float vB, int c)
    {
        float outcome = (v + vB) / (c + 1);
        return outcome;
    }

    public static float TimeBetweenTick(int t, int c, float p, float pB, float aV)
    {
        float outcome = ((t + 1) + (c + 1)) / ((p + pB) + aV);
        return outcome;
    }

    public static float InfluenceGainedPerSecond(float v, float vB, float p, float pB, int t, int c)
    {
        float outcome = ((v + vB) + (p + pB)) / ((t + 1) + (c + 1));
        return outcome;
    }

    public static float InfluenceGainedPerTick(float iG)
    {
        float outcome = iG * 4;
        return outcome;
    }

    public static float CorporateInfluenceDecrease(float iG)
    {
        float outcome = iG / 40;
        return outcome;
    }

    public static float ChitsEarned(float iG, float c)
    {
        float outcome = (iG / 10) * (c + 1);
        return outcome;
    }
}

