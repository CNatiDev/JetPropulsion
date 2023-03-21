using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class GameManager : MonoBehaviour
{
    private GameObject MainPlayer;
    private BuildingGenerator BuildingGenerator;
    public VariableJoystick Joystick;
    public Slider FuelSlider;
    public CinemachineVirtualCamera MainPlayerCamera;
    public GameObject FinalImage;
    [HideInInspector]
    public bool press = false;
    private Fuel_Object[] Fuel;
    public void Assign()
    {
        MainPlayer = GameObject.FindGameObjectWithTag("Player");
        BuildingGenerator = FindObjectOfType<BuildingGenerator>();
        ScoreManager score = FindObjectOfType<ScoreManager>();
        score.Play = true;
        Fuel = FindObjectsOfType<Fuel_Object>();
        if (MainPlayer != null)
        {
            MainPlayer.GetComponent<JetPropulsion>().variableJoystick = Joystick;
            MainPlayer.GetComponent<JetPropulsion>().FuelSlider = FuelSlider;
            BuildingGenerator.player = MainPlayer.transform;
            MainPlayerCamera.m_Follow = MainPlayer.transform;
            MainPlayerCamera.m_LookAt = MainPlayer.transform;
            MainPlayer.GetComponent<HitObstacle>().Final = FinalImage;
            for (int i = 0; i < Fuel.Length; i++)
                Fuel[i].Player = MainPlayer;
        }

    }
    //For MainPlyer propulsion button
    public void OnButtonPressed()
    {
        press = true;
    }
    public void OnButtonReleased()
    {
        press = false;
    }
}
