using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SaveIsBuy save pilot buy status 
//CurrentPilot save pilot last pilot refference
//MoneyAmount save money amount after buy or add
//Score save score while player play
public class SaveManager : MonoBehaviour
{
    private ShopManager Shop;

    void Awake()
    {
        Shop = FindObjectOfType<ShopManager>();
    }
    public void SaveShop()
    {
        PlayerPrefs.SetInt("SaveIsBuy" + Shop.CurrentPilot, Shop.IsBuy[Shop.CurrentPilot] ? 1 : 0);
        PlayerPrefs.SetInt("CurrentPilot", Shop.CurrentPilot);
        PlayerPrefs.Save();
    }
    public void SaveScore()
    {
        ScoreManager score = FindObjectOfType<ScoreManager>();
        PlayerPrefs.SetFloat("Score", score.Score);
        PlayerPrefs.Save();
    }
    public void SaveMoneyAmount()
    {
        PlayerPrefs.SetFloat("MoneyAmount", Shop.PlayerMoneyAmount);
        PlayerPrefs.Save();
    }

}
