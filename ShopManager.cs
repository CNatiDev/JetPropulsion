using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopManager : MonoBehaviour
{   [Header("SpawnPrefab")]
    #region
    public GameObject[] PilotPrefab; //Pilots for spawn
    public GameObject[] Pilots; //PilotSpawned
    public GameObject[] PhysicsPilotPrefab;//Physic Pilots for spawn
    public Transform SpwanPointPhysicsPilot; //Physic Pilots point for spawn
    #endregion
    [Header("ShopUi")]
    #region 
    [SerializeField] public bool[] IsBuy; //Buy Status
    public float[] Price;//Pilot price
    public Image LockIcon;
    public Button SelectButton;
    public Button BuyButton;
    public float PlayerMoneyAmount;
    public TextMeshProUGUI TextPrice;
    public TextMeshProUGUI MoneyAmountText;
    public Image IconMoney;
    #endregion
    #region Managers
    private GameManager GameManager;
    private SaveManager SaveManager;
    #endregion
    public int CurrentPilot = 0; //Pilot refference

    private void Start()
    {
        #region GetSave
        GameManager = FindObjectOfType<GameManager>();
        SaveManager = FindObjectOfType<SaveManager>();
        if (PlayerPrefs.HasKey("MoneyAmount"))
            PlayerMoneyAmount = PlayerPrefs.GetFloat("MoneyAmount", 100);
        if (PlayerPrefs.HasKey("Score"))
            PlayerMoneyAmount += PlayerPrefs.GetFloat("Score");
        SaveManager.SaveMoneyAmount();
        MoneyAmountText.text = PlayerMoneyAmount.ToString("F0");
        if (PlayerPrefs.HasKey("CurrentPilot"))
            CurrentPilot = PlayerPrefs.GetInt("CurrentPilot", 0);
        for (int i = 1; i < IsBuy.Length; i++)
        {
            if (PlayerPrefs.HasKey("SaveIsBuy" + i))
            {
                IsBuy[i] = PlayerPrefs.GetInt("SaveIsBuy" + i,0) == 1;
            }

        }
        #endregion
        Instantiate(PilotPrefab[CurrentPilot], this.transform.position, this.transform.rotation);
        Instantiate(PhysicsPilotPrefab[CurrentPilot], SpwanPointPhysicsPilot.position, SpwanPointPhysicsPilot.rotation);
        GameManager.Assign();
        IsBuyPilot();
    }
    private void Update()
    {
        Pilots = GameObject.FindGameObjectsWithTag("Shop");
    }
    public void NextPilot()
    {
        if (CurrentPilot + 1 >= PilotPrefab.Length)
        {
            CurrentPilot = -1;
        }
        if (CurrentPilot < PilotPrefab.Length - 1)
        {
            Instantiate(PilotPrefab[CurrentPilot + 1], this.transform.position, this.transform.rotation);
            Destroy(Pilots[0]);

        }
        CurrentPilot++;
        IsBuyPilot();

    }
    public void PerviousPilot()
    {
        if (CurrentPilot == 0)
            CurrentPilot = PilotPrefab.Length;
        if (CurrentPilot > 0)
        {
            Instantiate(PilotPrefab[CurrentPilot - 1], this.transform.position, this.transform.rotation);
            Destroy(Pilots[0]);
        }
        CurrentPilot--;
        IsBuyPilot();

    }
    public void selectPilot()
    {
        if (IsBuy[CurrentPilot])
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Instantiate(PhysicsPilotPrefab[CurrentPilot], SpwanPointPhysicsPilot.position, SpwanPointPhysicsPilot.rotation);
            GameManager.Assign();
            SaveManager.SaveShop();
            SaveManager.SaveMoneyAmount();
        }
    }
    public void OpenShopTab()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
    public void Buy()
    {
        if (PlayerMoneyAmount >= Price[CurrentPilot])
        {   IsBuy[CurrentPilot] = true;
            PlayerMoneyAmount -= Price[CurrentPilot];
            MoneyAmountText.text = PlayerMoneyAmount.ToString("F0");
            IsBuyPilot();
            SaveManager.SaveShop();
        }
    }
    void IsBuyPilot()
    {
        if (IsBuy[CurrentPilot] == false)
        {
            LockIcon.gameObject.SetActive(true);
            SelectButton.gameObject.SetActive(false);
            TextPrice.gameObject.SetActive(true);
            BuyButton.gameObject.SetActive(true);
            TextPrice.text = Price[CurrentPilot].ToString();
        }
        else
        {
            LockIcon.gameObject.SetActive(false);
            SelectButton.gameObject.SetActive(true);
            TextPrice.gameObject.SetActive(false);
            BuyButton.gameObject.SetActive(false);
        }
        if (PlayerMoneyAmount < Price[CurrentPilot])
        {
            BuyButton.interactable = false;
        }
        else
        {
            BuyButton.interactable = true;

        }
    }
}