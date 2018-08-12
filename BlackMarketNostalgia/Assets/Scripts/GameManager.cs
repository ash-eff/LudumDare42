using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public delegate void OutcomeEvent();
    public static event OutcomeEvent PlayerSuccess;
    public static event OutcomeEvent CorporateSuccess;
    public static event OutcomeEvent NoSuccess;
    public float time = 0;
    public float amountToUnlockNextNeighborhood;
    public Button unlockButton;
    public Button dispenseButton;

    private float adjustedVoice;

    Neighborhood selectedNeighborhood;
    Player player;
    GUIManager guiManager;

    public void SetSelectedNeighborhood(Neighborhood neightborhood) { selectedNeighborhood = neightborhood; }
    public Neighborhood GetSelectedNeighborhood() { return selectedNeighborhood; }

    private void Start()
    {
        guiManager = FindObjectOfType<GUIManager>();
        player = FindObjectOfType<Player>();
        amountToUnlockNextNeighborhood = 400;
}

    private void Update()
    {
        CheckForUnlock();
        CheckForDispense();
    }

    private void CheckForUnlock()
    {
        if (player.m_influence >= amountToUnlockNextNeighborhood)
        {
            unlockButton.interactable = true;
        }
        else
        {
            unlockButton.interactable = false;
        }
    }

    private void CheckForDispense()
    {
        if(selectedNeighborhood != null)
        {
            if (!selectedNeighborhood.isPlayerDispensing && selectedNeighborhood.isUnlocked)
            {
                dispenseButton.interactable = true;
            }
            else
            {
                dispenseButton.interactable = false;
            }
        }
    }

    public void UnlockNeighborhood()
    {
        selectedNeighborhood.isUnlocked = true;
        IncreaseUnlockCost();
    }

    public void DispenseNostalgia()
    {
        selectedNeighborhood.isPlayerDispensing = true;
        guiManager.m_distributing.text = "Distributing: " + selectedNeighborhood.isPlayerDispensing.ToString();
    }

    public void IncreaseUnlockCost()
    {
        Mathf.RoundToInt(amountToUnlockNextNeighborhood *= 1.5f);
    }
}
