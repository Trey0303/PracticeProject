using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] private Text health, level;
    [SerializeField] private Image healthFill, levelFill;
    [SerializeField] private Player player;

    //Stats UI elements
    private List<Text> playerStatTexts = new List<Text>();
    [SerializeField] private Text playerStatPrefab;
    [SerializeField] private Transform playerStatPanel;

    //Equipped Weapon UI elements
    [SerializeField] private Sprite defaultWeaponSprite;
    private PlayerWeaponController playerWeaponController;
    [SerializeField] private Text weaponStatPrefab;
    [SerializeField] private Transform weaponStatPanel;
    [SerializeField] private Text weaponNameText;
    [SerializeField] private Image weaponIcon;
    private List<Text> weaponStatTexts = new List<Text>();

    // Start is called before the first frame update
    void Awake()//this needs to happen before calling InitalizeStats function inside the start function to avoid null reference errors. that is why there is an awake and start in this script
    {
        playerWeaponController = player.GetComponent<PlayerWeaponController>();
        UIEventHandler.OnPlayerHealthChanged += UpdateHealth;
        UIEventHandler.OnStatsChanged += UpdateStats;
        UIEventHandler.OnItemEquipped += UpdateEquippedWeapon;
        
    }

    private void Start()
    {
        InitializeStats();
    }

    void UpdateHealth(int currentHealth, int maxHealth)
    {
        this.health.text = currentHealth.ToString();
        this.healthFill.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    //adds a new stats to UI
    void InitializeStats()
    {
        //Debug.Log("Stat init");
        for (int i = 0; i < player.characterStat.stats.Count; i++)
        {
            playerStatTexts.Add(Instantiate(playerStatPrefab));
            playerStatTexts[i].transform.SetParent(playerStatPanel);

        }
        UpdateStats();
    }

    //updates stats in UI
    void UpdateStats()
    {
        for (int i = 0; i < player.characterStat.stats.Count; i++)
        {
            playerStatTexts[i].text = player.characterStat.stats[i].StatName + ": " + player.characterStat.stats[i].GetCalculatedStatValue().ToString();

        }
    }

    //void EquipWeapon(Item item){
    //    Debug.Log(item.ItemName);
    //}

    void UpdateEquippedWeapon(Item item)
    {
        weaponIcon.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug);
        weaponNameText.text = item.ItemName;

        //this for loop is doing the same thing as the InitializeStats() and UpdateStats() functions. Just changed to work with weapon stats instead
        for (int i = 0; i < item.Stats.Count; i++)
        {
            weaponStatTexts.Add(Instantiate(weaponStatPrefab));
            weaponStatTexts[i].transform.SetParent(weaponStatPanel);
            weaponStatTexts[i].text = item.Stats[i].StatName + ": " + item.Stats[i].GetCalculatedStatValue().ToString();
        }
    }

    public void UnequipWeapon()
    {
        weaponNameText.text = "-";
        weaponIcon.sprite = defaultWeaponSprite;
        for(int i = 0; i < weaponStatTexts.Count; i++)
        {
            Destroy(weaponStatTexts[i].gameObject);
        }
        playerWeaponController.UnequipWeapon();
    }
}
