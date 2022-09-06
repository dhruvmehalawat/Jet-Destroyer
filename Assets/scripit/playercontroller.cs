using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playercontroller : MonoBehaviour
{
    [Header("Input System Manager")]
    [SerializeField] InputAction movment;
    [SerializeField] InputAction fire;
    
    [Header("Genral Setup Setting")]
    [Tooltip("How fast ship moves up and down")][SerializeField] float movmentSpeed= 15f;
    [Tooltip("Restrict ship movement scope on X axis")][SerializeField] float xRange = 5f;
    [Tooltip("Restrict ship movement scope on Y axis")][SerializeField] float yRange = 5f;
    [Header("Screen Postion Based Tuning")]
    [SerializeField] float postionPitchFactor = -5f;
    [SerializeField] float postionYawFactor = 2f;

    [Header("Player Input Based Tuning")]
    [SerializeField] float controlPitchfactor = -10f;
    [SerializeField] float controlrollfactor = -20f;

    [Header("Laser Array")]
    [Tooltip("Add All Lasers")][SerializeField] GameObject[] lasers;

    float verticalthrow,horizontalthrow;

    void OnEnable() {
        movment.Enable();
        fire.Enable();
    }
    void OnDisable() {
         movment.Disable();
         fire.Disable();

    }

    // Update is called once per frame
    
    void Update()
    {
        ProcessMovement();
        ProcessRotation();
        ProcessFiring();
    }
    void ProcessRotation(){
        float pitchDuetoPostion = transform.localPosition.y * postionPitchFactor;
        float pitchDuetoControlThrow= verticalthrow*controlPitchfactor;

        float yawduetotoPosition = transform.localPosition.x * postionYawFactor;

        float rollduetoControlThrow = horizontalthrow*controlrollfactor;

        float pitch = pitchDuetoPostion + pitchDuetoControlThrow;
        float yaw = yawduetotoPosition;
        float roll = rollduetoControlThrow;

        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }
    void ProcessMovement(){
        horizontalthrow = movment.ReadValue<Vector2>().x;
        verticalthrow = movment.ReadValue<Vector2>().y;

        float xoffset = horizontalthrow * Time.deltaTime *movmentSpeed;
        float newposX = transform.localPosition.x + xoffset;

        float yoffset = verticalthrow * Time.deltaTime *movmentSpeed;
        float newposy = transform.localPosition.y + yoffset;

        float clampXpostion = Mathf.Clamp(newposX,-xRange,xRange);
        float clampYpostion = Mathf.Clamp(newposy,-yRange,yRange);

        transform.localPosition = new Vector3(clampXpostion,clampYpostion,transform.localPosition.z);

    }
    void ProcessFiring(){
        if(fire.ReadValue<float>() > 0.1 ){
            fireActive(true);
        }
        else{
            fireActive(false);
        }
    }
    void fireActive(bool isActive){
        foreach(GameObject laser in lasers){
            laser.GetComponent<ParticleSystem>().enableEmission=isActive;
        }
    }
}
