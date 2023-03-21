using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Fuel_Object : MonoBehaviour
{
    public float Fuel_Quantity;
    public GameObject Player;
    private JetPropulsion JetPropulsion;
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        this.transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Player")       
            {
            AddFuel();
            this.gameObject.SetActive(false);
            }
        
    }
    void AddFuel()
    {
        if (Player != null)
        {
            JetPropulsion = Player.GetComponent<JetPropulsion>();
            JetPropulsion.AddFuel = Fuel_Quantity;//Set the amount to be added to Fuel, because the bottles are of different sizes
            JetPropulsion.InFuel = true;//Send to Jet Propulsion the fact that it is in trigger
            JetPropulsion.OldFuelLevel = JetPropulsion.FuelSlider.value;
            JetPropulsion.OldFuelLevel = JetPropulsion.FuelLevel;//Save the old value to see how far it should be loaded
        }
    }


}
