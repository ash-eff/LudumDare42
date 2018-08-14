using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static int neighborhoodsFreed;
    public static int neighborhoodsUnlocked = 1;

    public float timer = 5;
    public float amountToUnlockNextNeighborhood;
    public Button unlockButton;
    public Button dispenseButton;
    public Image winScreen;
    public int test;
    private float adjustedVoice;

    public Neighborhood selectedNeighborhood;
    Player player;
    GUIManager guiManager;

    public void SetSelectedNeighborhood(Neighborhood neightborhood) { selectedNeighborhood = neightborhood; }
    public Neighborhood GetSelectedNeighborhood() { return selectedNeighborhood; }

    private void Start()
    {
        timer = 20f;
        guiManager = FindObjectOfType<GUIManager>();
        player = FindObjectOfType<Player>();
        amountToUnlockNextNeighborhood = 400;
}

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            player.m_persistenceBoost = (player.m_influence * player.m_persistence) * .0001f;
            timer = 20f;
        }

        test = neighborhoodsFreed;

        if (neighborhoodsFreed == 22)
        {
            Time.timeScale = 0;
            winScreen.gameObject.SetActive(true);
        }

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
        if (selectedNeighborhood == null)
        {
            Debug.Log("OOPS");
        }

        if (!selectedNeighborhood.isUnlocked)
        {
            selectedNeighborhood.isUnlocked = true;
            neighborhoodsUnlocked += 1;
            IncreaseUnlockCost();
        }

    }

    public void DispenseNostalgia()
    {
        selectedNeighborhood.isPlayerDispensing = true;
        guiManager.m_distributing.text = "Distributing: " + selectedNeighborhood.isPlayerDispensing.ToString();
    }

    public void IncreaseUnlockCost()
    {
        Mathf.RoundToInt(amountToUnlockNextNeighborhood *= 2f);
    }
}
