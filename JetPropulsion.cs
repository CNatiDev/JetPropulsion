/*  -This script is for a jet propulsion system in Unity using the MonoBehaviour class. It utilizes the UnityEngine 
library for physics and input, as well as the System.Collections and System.Collections.Generic libraries. 
    -The script defines public variables for thrust, horizontal and vertical move speed, and a rigidbody component for 
the jet. 
    -It also has variables for balancing the jet when turning left and right. The Start() method sets the 
rigidbody component and the Update() method handles input for movement and turning. 
    -The Turn_Left_Right() method is called in the Update method and handles rotation of the jet when the A or D keys are pressed.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class JetPropulsion : MonoBehaviour
{
    #region [Header("Physics Settings")]
    public float thrust;
    public float moveSpeedHorizontal;
    public float moveSpeedVertical;
    public float Speed;
    public float maxHeight;
    private float OldThrust;
    public float speed;
    #endregion
    #region [Header("MyJet")]
    public Rigidbody rb;
    public ParticleSystem[] Flames;
    #endregion
    #region [Header("Balance")]
    public float maxBalanceR;
    public float maxBalanceL;
    private float tR = 0.3f;
    private float tL = 0.3f;
    private float tB = 0.3f;
    #endregion
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        OldThrust = thrust;
    }

    void Update()
    {   
        #region Propulsion 
        if (press)
        {
            rb.AddRelativeForce(Vector3.up * thrust);
            for (int i = 0; i < Flames.Length; i++)
                Flames[i].Play();
        }
        else
        {
            for (int i = 0; i < Flames.Length; i++)
                Flames[i].Stop();
        }
        #endregion
        #region Height Limit
        if (rb.gameObject.transform.localPosition.y > maxHeight)
        {
            thrust = 0;
            for (int i = 0; i < Flames.Length; i++)
                Flames[i].Stop();
        }
        else if (rb.gameObject.transform.localPosition.y < maxHeight)
        {
            thrust = OldThrust;
        }
        #endregion
        #region Horizontal Mouvment 
        Vector3 direction = Vector3.right* variableJoystick.Horizontal;
        rb.AddForce(-direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        if (variableJoystick.Horizontal > 0)
        {
            rb.gameObject.transform.localRotation = Quaternion.Euler(0, 180, Mathf.LerpAngle(rb.gameObject.transform.localRotation.z, maxBalanceR, tR));
            tR += 0.05f * Time.time;
            tB = 0.3f;
        }
        if (variableJoystick.Horizontal < 0)
        {
            rb.gameObject.transform.localRotation = Quaternion.Euler(0, 180, Mathf.LerpAngle(rb.gameObject.transform.localRotation.z, maxBalanceL,  tL));
            tL += 0.05f * Time.time;
            tB = 0.3f;
        }
        if (variableJoystick.Horizontal == 0.0)
        {
            tL = 0.3f;
            tR = 0.3f;
            rb.gameObject.transform.localRotation = Quaternion.Euler(0, 180, Mathf.LerpAngle(rb.gameObject.transform.localRotation.z, 0.0f, tB));
            tB += 0.1f * Time.deltaTime;
        }
        #endregion
        #region Vertical Mouvment 
        Vector3 movementV = new Vector3(0.0f, 0.0f, Speed);
        Speed += 0.1f*Time.deltaTime;
        rb.AddRelativeForce(movementV * moveSpeedVertical);
        #endregion

    }
    #region UI Inputs
    bool press = false;
    public VariableJoystick variableJoystick;
    public void UiButtonDown()
    {
        press = true;
    }
    public void UiButtonUp()
    {
        press = false;
    }
    #endregion
}
