using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    //float xRotation = 0f;

    //////////////////////////////  
    // Test for input system 
    InputMaster controls;
    bool rotateRightStatus = false;
    bool rotateLeftStatus = false;
    bool rotateUpStatus = false;

    ///////\\\\\\\\\\
    // Connect unity to nodeJS server
    public SocketIOComponent socket; 

    void Awake(){
        Debug.Log("Awake: Mouse ");
        controls = new InputMaster();

        controls.Avatar.RotateRight.performed += ctx => RotateRight();
        //controls.GamePlay.RotateX.started += ctx => RotateRight();
        controls.Avatar.RotateRight.canceled += ctx => CancelRotateRight();

        controls.Avatar.RotateLeft.performed += ctx => RotateLeft();
        //controls.GamePlay.RotateX.started += ctx => RotateRight();
        controls.Avatar.RotateLeft.canceled += ctx => CancelRotateLeft();

        // No need now
        /* controls.Avatar.RotateUp.performed += ctx => RotateUp();
        //controls.GamePlay.RotateX.started += ctx => RotateRight();
        controls.Avatar.RotateUp.canceled += ctx => CancelRotateUp(); */
    }

    // ToDO you can reduce the code by using one function
    void RotateRight(){
        Debug.Log("rotate right: "+ transform.eulerAngles.x);
        rotateRightStatus = true;
    }
    void CancelRotateRight(){
         Debug.Log("CancelRotate: ");
        rotateRightStatus = false;
    }

    void RotateLeft(){
        Debug.Log("rotate left: "+ transform.eulerAngles.x);
        rotateLeftStatus = true;
    }
    void CancelRotateLeft(){
         Debug.Log("CancelRotate: ");
        rotateLeftStatus = false;
    }

    // ToDo: Update it (// No need now)
    /* void RotateUp(){
         Debug.Log("rotate up: "+ transform.position.x);
        rotateUpStatus = true;
    }
    void CancelRotateUp(){
         Debug.Log("CancelRotate: ");
        rotateUpStatus = false;
    } */

    // Important to be able to use the controls
    void OnEnable(){
        controls.Avatar.Enable();
    }
    void OnDisable(){
        controls.Avatar.Disable();
    }

    ///////////////////////////////////////////////
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; // Lock cursor
        Cursor.visible = false;

        // repeat sending heading every second
        // source: https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html
        InvokeRepeating("SendAvatarHeadingEverySecond", 1.0f, 0.5f);
    }

    void SendAvatarHeadingEverySecond()
    {
        // Send avatar direction to server every second
         Dictionary<string, string> avatarHeading = new Dictionary<string, string>();
        avatarHeading["x_axis"] = playerBody.rotation.eulerAngles.y.ToString();
        //if(rotateRightStatus || rotateLeftStatus){
            socket.Emit("updateAvatarDirection", new JSONObject(avatarHeading)); 
        //} 
    }

    // Update is called once per frame
    void Update()
    {
        // show rotion value
        //Debug.Log("rotation y: "+ playerBody.rotation.eulerAngles.y);
        //Debug.Log("transform.x: "+ playerBody.position.x);

        // Moved to  SendAvatarHeadingEverySecond() // 30.06.21
        // Send avatar direction to server
        Dictionary<string, string> avatarHeading = new Dictionary<string, string>();
        avatarHeading["x_axis"] = playerBody.rotation.eulerAngles.y.ToString();
        //data["y_axis"] = transform.position.z.ToString();
        
        // Send rotation angle to server, when avater directoin is changed
        if(rotateRightStatus || rotateLeftStatus){
            socket.Emit("updateAvatarDirection", new JSONObject(avatarHeading)); 
        }
        

        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        //xRotation -= mouseY;
        //xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // up and down
        //playerBody.Rotate(Vector3.up * mouseX); // left and right

        if(rotateRightStatus){
            float mouseX = (transform.eulerAngles.x+0.5f) * mouseSensitivity * Time.deltaTime;
            playerBody.Rotate(Vector3.up * mouseX); // right
        }else if(rotateLeftStatus){
            float mouseX = (transform.eulerAngles.x-0.5f) * mouseSensitivity * Time.deltaTime;
            playerBody.Rotate(Vector3.up * mouseX); // left
        }else if(rotateUpStatus){
            /* float mouseY = (transform.rotation.x + 0.1f) * mouseSensitivity * Time.deltaTime;
            //xRotation -= mouseY;
            xRotation = Mathf.Clamp(mouseY, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // up  */

            //transform.rotation.x += 0.1f;
        }
        
    }
}
