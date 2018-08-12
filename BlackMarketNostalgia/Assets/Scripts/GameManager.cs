using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public delegate void OutcomeEvent();
    public static event OutcomeEvent PlayerSuccess;
    public static event OutcomeEvent CorporateSuccess;
    public static event OutcomeEvent NoSuccess;
    public float time = 0;

    public float amountToUnlockNextNeighborhood;

    private float adjustedVoice;

    Neighborhood selectedNeighborhood;
    Player player;

    public void SetSelectedNeighborhood(Neighborhood neightborhood) { selectedNeighborhood = neightborhood; }
    public Neighborhood GetSelectedNeighborhood() { return selectedNeighborhood; }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        amountToUnlockNextNeighborhood = 4000;
}

    private void Update()
    {
        CalculateStats();
    }

    public void DisplayCalculations()
    {
        if (!selectedNeighborhood.GetIsDeductingInfluence())
        {
            selectedNeighborhood.SetIsDeductingInfluence(true);
            selectedNeighborhood.StartCoroutine(selectedNeighborhood.DeductInfluence());
            
        }
        else
        {
            Debug.Log("Already Displaying Calculations For " + selectedNeighborhood.name);
        }
    }

    public void IncreaseUnlockCost()
    {
        Mathf.RoundToInt(amountToUnlockNextNeighborhood *= 1.5f);
    }

    public void CalculateStats()
    {
        if (selectedNeighborhood != null && selectedNeighborhood.GetIsDeductingInfluence())
        {
            player.SetAdjustedVoice((player.GetVoice() + player.GetVoiceBoost()) / ((int)selectedNeighborhood.GetClass() + 1));
            adjustedVoice = player.GetAdjustedVoice();
            time = (((int)selectedNeighborhood.GetTemperament() + 1) + ((int)selectedNeighborhood.GetClass() + 1)) / (player.GetPersistence() + player.GetPersistenceBoost() + adjustedVoice);
            selectedNeighborhood.SetTime(time);           
        }
    }   
}
