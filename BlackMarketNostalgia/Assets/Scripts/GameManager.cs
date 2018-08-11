using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public delegate void OutcomeEvent();
    public static event OutcomeEvent PlayerSuccess;
    public static event OutcomeEvent CorporateSuccess;
    public static event OutcomeEvent NoSuccess;
    
    Neighborhood selectedNeighborhood;
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void SetSelectedNeighborhood(Neighborhood neightborhood) { selectedNeighborhood = neightborhood; }

    public void CalculateStats()
    {
        if(selectedNeighborhood != null)
        {
            float neighborhoodStatTotal = ((int)selectedNeighborhood.m_temperament + 1 * (int)selectedNeighborhood.m_income + 1) +
                                selectedNeighborhood.m_corporateInfluence;
            print("Neightborhood Stats: " + neighborhoodStatTotal);

            float playerStatTotal = player.m_influence * player.m_voice + player.m_supplyQuality;
            print("Player stats: " + playerStatTotal);

            if (playerStatTotal > neighborhoodStatTotal)
            {
                if (PlayerSuccess != null)
                {
                    PlayerSuccess();
                }
            }
            else if (playerStatTotal < neighborhoodStatTotal)
            {
                if (CorporateSuccess != null)
                {
                    CorporateSuccess();
                }
            }
            else
            {
                if (NoSuccess != null)
                {
                    NoSuccess();
                }
            }
        }

        else
        {
            Debug.Log("No neighborhood selected");
        }
    }   
}
