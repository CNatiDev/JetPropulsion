using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] public float Score;
    public TextMeshProUGUI ScoreText;
    public bool Play = false;
    private SaveManager SaveManager;
    private void Start()
    {
        SaveManager = FindObjectOfType<SaveManager>();
    }
    void Update()
    {   if (Play)
        {
            Score += 0.5f * Time.deltaTime;
            ScoreText.text = Score.ToString("F2");
            SaveManager.SaveScore();
        }
    }
}
