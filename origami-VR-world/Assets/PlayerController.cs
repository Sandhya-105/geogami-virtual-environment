using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public Animator anim;
    
    //public Transform playerBody; You can delete it

    public float gravity = -9.81f;
    Vector3 velocity;

    //public Transform groundCheck;
    public float groundDistance = 0.4f;
    //public LayerMask groundMask;
    bool isGrounded;

    public CharacterController controller;

    /* To Change the avatar's speed */
    int desiredSpeed = 1;

    ///////\\\\\\\\\\
    public SocketIOComponent socket; // connect unity to nodeJS server
    bool movemwntStatus = false;

    /////////////////////////////  
    // Test for input system 
    InputMaster controls;

    // To controller slider using controller 1/3
    public Slider speedSliderInstance;

    void Awake(){
        Debug.Log("Awake: ");
        controls = new InputMaster();

        //controls.GamePlay.Front.performed += ctx => WalkFWD();
        
        // avatar WalkFWD
        controls.Avatar.WalkFWD.started += ctx => WalkFWD();
        controls.Avatar.WalkFWD.canceled += ctx => CancelWalkFWD();

        // avatar WalkBWD
        controls.Avatar.WalkBWD.started += ctx => WalkBWD();
        controls.Avatar.WalkBWD.canceled += ctx => CancelWalkBWD();

        // increase avatar speed
        controls.Avatar.SpeedUp.started += ctx => SpeedUp();
        //controls.Avatar.SpeedUp.canceled += ctx => CancelSpeedUp();

        // decrease avatar speed
        controls.Avatar.SpeedDown.started += ctx => SpeedDown();
        //controls.Avatar.SpeedDown.canceled += ctx => CancelSpeedDown();

        // No need for them right now
        /* controls.Avatar.WalkRight.started += ctx => TurnRight();
        controls.Avatar.WalkRight.canceled += ctx => CancelTurnRight();

        controls.Avatar.WalkLeft.started += ctx => TurnLeft();
        controls.Avatar.WalkLeft.canceled += ctx => CancelTurnLeft(); */
    }

    // avatar WalkBWD
    void WalkFWD(){
         movemwntStatus = true;
         Debug.Log("WalkFWD: ");
         anim.SetFloat("vertical", 1.0f);

    }
    void CancelWalkFWD(){
        movemwntStatus = false;
        Debug.Log("CancelWalkFWD: ");
        anim.SetFloat("vertical", 0.0f);

    }
    
    // avatar WalkBWD
    void WalkBWD(){
         movemwntStatus = true;
         Debug.Log("WalkBWD: ");
         anim.SetFloat("vertical", -1.0f);

    }
    void CancelWalkBWD(){
        movemwntStatus = false;
        Debug.Log("CancelWalkBWD: ");
        anim.SetFloat("vertical", 0.1f);
    }

    // increase avatar speed
    void SpeedUp(){
        if(speedSliderInstance.value < 7){
            speedSliderInstance.value += 1;
        }
        Debug.Log("speedSliderInstance.value: "+ speedSliderInstance.value);
    }

    // decrease avatar speed
    void SpeedDown(){
         if(speedSliderInstance.value > 1){
            speedSliderInstance.value -= 1;
        }
        Debug.Log("speedSliderInstance.value: "+ speedSliderInstance.value);

    }

// Important to be able to use the controls
    void OnEnable(){
        controls.Avatar.Enable();
    }
    void OnDisable(){
        controls.Avatar.Disable();
    }
    //////////////////////////////


    void Start(){
        controller = GetComponent<CharacterController>();
        /* To Change the avatar's speed */
        Debug.Log("desiredSpeed: ///////////////");
        anim.speed = 3;

        // Receive Data from ionic, use it in case you would like to make initial avatar loc dynamic 1/2
        //socket.On("avatarStartPosition", GetAvatarInitialPosition);

        // To controller slider using controller 2/3
        //speedSliderInstance.value += 1;
        //Debug.Log("speedSliderInstance.value: "+ speedSliderInstance.value);

    }

    // Receive Data from ionic, use it in case you would like to make initial avatar loc dynamic 2/2
    /* public void GetAvatarInitialPosition(SocketIOEvent e){
		Debug.Log("***e: " + e.data);

        //transform.position.x = e.data[1];
        //playerBody.transform.x = e.data[1];
        //float coord1 = e.data["x"];
        //Debug.Log("***coords: " + coords);

        //transform.position = new Vector3(e.data["x"][1], transform.position.y, e.data["x"][0]);

	} */

    void Update()
    {
        // Send avatar position to server
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["x_axis"] = transform.position.x.ToString();
        data["y_axis"] = transform.position.z.ToString();
        if(movemwntStatus){
            socket.Emit("updateAvatarPosition", new JSONObject(data)); 
        }

        /* isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        } */

        // collider, for further info  check in 17:40 (https://www.youtube.com/watch?v=_QajrabyTJc)
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    public void ChangeSpeed(float speedV){
        /* To Change the avatar's speed */
        Debug.Log("desiredSpeed: ///////////////");
        anim.speed = speedV;
        Debug.Log("desiredSpeed: " + speedV);
        Debug.Log("/////////////// desiredSpeed:");
    }
}
