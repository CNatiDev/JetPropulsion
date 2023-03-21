using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] Fuels;
    private void Awake()
    {
        for (int i = 0; i < Fuels.Length; i++)
            Fuels[i].SetActive(false);
        for (int i = 0; i < 3; i++)
        {
            int j = Random.Range(0, Fuels.Length);
            Fuels[j].SetActive(true);
        }
        
    }
}
