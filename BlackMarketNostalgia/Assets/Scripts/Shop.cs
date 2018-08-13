using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour {

    public GameObject window;

    public Text upgradeName;
    public Text flavorText;
    public Text chitCost;

    public Upgrade currentUpgrade;

    public void SetCurrentUpgrade(Upgrade x) { currentUpgrade = x; }

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void OpenWindow()
    {
        if (window.activeSelf == false)
        {
            window.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void CloseWindow()
    {
        if(window.activeSelf == true)
        {           
            window.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void LoadUpgrade()
    {
        currentUpgrade = EventSystem.current.currentSelectedGameObject.GetComponent<Upgrade>();
        upgradeName.text = currentUpgrade.name;
        flavorText.text = currentUpgrade.flavorText.text;
        chitCost.text = "Chits: " + currentUpgrade.chitCost.ToString();
    }

    public void BuyUpgrade()
    {
        if (player.m_chits >= currentUpgrade.chitCost && !currentUpgrade.purchased)
        {
            player.m_chits -= currentUpgrade.chitCost;
            player.m_voiceBoost += currentUpgrade.upgradeAmount;
            currentUpgrade.purchased = true;
        }
    }
}
