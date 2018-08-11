using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    

    public delegate void OutcomeEvent();
    public static event OutcomeEvent PlayerSuccess;
    public static event OutcomeEvent CorporateSuccess;
    public static event OutcomeEvent NoSuccess;
    public float time = 0;

    Neighborhood selectedNeighborhood;
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void SetSelectedNeighborhood(Neighborhood neightborhood) { selectedNeighborhood = neightborhood; }
    public Neighborhood GetSelectedNeighborhood() { return selectedNeighborhood; }

    public void CalculateStats()
    {
        if (selectedNeighborhood != null)
        {
            player.SetAdjustedVoice(player.GetVoice() / ((int)selectedNeighborhood.GetClass() + 1));
            float adjustedVoice = player.GetAdjustedVoice();

            time = (((int)selectedNeighborhood.GetTemperament() + 1) + ((int)selectedNeighborhood.GetClass() + 1)) / (player.GetPersistence() + player.GetPersistenceBoost() + adjustedVoice);
            selectedNeighborhood.SetTime(time);
        }
    }   
}
