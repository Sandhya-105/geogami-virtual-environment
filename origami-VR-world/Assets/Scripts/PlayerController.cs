using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public Animator anim;

    public float gravity = -9.81f;
    Vector3 velocity;
    public float groundDistance = 0.4f;
    bool isGrounded;
    public CharacterController controller;
    /* To Change the avatar's speed */
    int desiredSpeed = 1;
    /* SocketIO */
    public SocketIOComponent socket; // connect unity to nodeJS server
    bool movemwntStatus = false;
    /* Test for input system  */
    InputMaster controls;
    /* To controller slider using controller 1/3 */
    public Slider speedSliderInstance;
    /* Test Multiuser impl. 29.09.21 */
    public bool connectedToServer = false;

    void Awake()
    {
        Debug.Log("Awake: PlayerController");
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


        /* Test MultiUser impl. 05.10.21 */
        //Debug.Log("game code sent from menu scene : "+ TextTransfer.gameCode);

    }

    // avatar WalkBWD
    void WalkFWD()
    {
        movemwntStatus = true;
        Debug.Log("WalkFWD: ");
        anim.SetFloat("vertical", 1.0f);
    }
    void CancelWalkFWD()
    {
        movemwntStatus = false;
        Debug.Log("CancelWalkFWD: ");
        anim.SetFloat("vertical", 0.0f);

    }

    // avatar WalkBWD
    void WalkBWD()
    {
        movemwntStatus = true;
        Debug.Log("WalkBWD: ");
        anim.SetFloat("vertical", -1.0f);

    }
    void CancelWalkBWD()
    {
        movemwntStatus = false;
        Debug.Log("CancelWalkBWD: ");
        anim.SetFloat("vertical", 0.1f);
    }

    // increase avatar speed
    void SpeedUp()
    {
        if (speedSliderInstance.value < 8)
        {
            speedSliderInstance.value += 1;
        }
        Debug.Log("speedSliderInstance.value: " + speedSliderInstance.value);
    }

    // decrease avatar speed
    void SpeedDown()
    {
        if (speedSliderInstance.value > 6)
        {
            speedSliderInstance.value -= 1;
        }
        Debug.Log("speedSliderInstance.value: " + speedSliderInstance.value);

    }

    // Important to be able to use the controls
    void OnEnable()
    {
        controls.Avatar.Enable();
    }
    void OnDisable()
    {
        controls.Avatar.Disable();
    }
    //////////////////////////////


    void Start()
    {
        controller = GetComponent<CharacterController>();
        /* To Change the avatar's speed */
        Debug.Log("desiredSpeed: PlayerController");
        anim.speed = 7;


        // repeat sending loc every second
        // source: https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html
        InvokeRepeating("SendAvatarLocEverySecond", 1.0f, 0.3f); // Updated 10.08.21

        // Receive Data from ionic, use it in case you would like to make initial avatar loc dynamic 1/2
        //Temp
        socket.On("updateAvatarPosition", GetAvatarPosition);

        /* socket.On("updateAvatarPosition", (SocketIOEvent e) => {
		    Debug.Log("hello");
	    }); */

        // To controller slider using controller 2/3
        //speedSliderInstance.value += 1;
        //Debug.Log("speedSliderInstance.value: "+ speedSliderInstance.value);

        // Note: adding `socket.Emit("newGame");`  here doesn't work. No idea why ???
    }

    //Temp
    public void GetAvatarPosition(SocketIOEvent e)
    {
        Debug.Log("GetAvatarPosition::;;::");

    }


    void SendAvatarLocEverySecond()
    {
        /* Test MultiUser impl. 29.09.21 */
        if (!connectedToServer)
        {
            connectedToServer = true;

            //socket.Emit("joinGame", new JSONObject("{\"gameCode\": \""+TextTransfer.gameDetails["gameCode"]+"\"}")); // ToDO: change it to join game
            socket.Emit("joinGame", new JSONObject(TextTransfer.gameDetails));
        }

        // Send avatar position to server
        Dictionary<string, string> avatarPosition = new Dictionary<string, string>();
        avatarPosition["x_axis"] = transform.position.x.ToString();
        avatarPosition["y_axis"] = transform.position.z.ToString();
        /* Test MultiUser impl. 29.09.21 */

        avatarPosition["gameCode"] = TextTransfer.gameDetails["gameCode"];
        //if(movemwntStatus){
        //socket.Emit("updateAvatarPosition", new JSONObject(data)); 
        //}

        /* Test MultiUser impl. 29.09.21 */
        socket.Emit("updateAvatarPosition", new JSONObject(avatarPosition));





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

    void FixedUpdate()
    {


        // Moved to  SendAvatarLocEverySecond() // 30.06.21
        // Send avatar position to server // Updated 10.08.21
        /*Dictionary<string, string> data = new Dictionary<string, string>();
        data["x_axis"] = transform.position.x.ToString();
        data["y_axis"] = transform.position.z.ToString();
        if(movemwntStatus){
            socket.Emit("updateAvatarPosition", new JSONObject(data)); 
        }*/

        /* isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        } */

        // collider, for further info  check in 17:40 (https://www.youtube.com/watch?v=_QajrabyTJc)
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        // Put avatar above bridge in case it gets sink
        if (transform.position.y < 98.1)
        {
            Debug.Log("sink");
            //transform.position = new Vector3(263f, 104f, 211f);
            //transform.position =Vector3.Lerp(transform.position, new Vector3(263f, 220f, 211f), 500 * Time.fixedDeltaTime);

            // Temp
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 10f, 200f, transform.position.z + 30f), 500 * Time.fixedDeltaTime);
        }

        //GameObject go= GameObject.Find("Avatar");
        //Debug.Log("go.transform.position= "+ go.transform.position);
        /*
        Vector3 move = Vector3.MoveTowards(transform.position, new Vector3(263f, 104f, 211f), 20 * Time.fixedDeltaTime);
        move.y = 0.91f;
        transform.position = move;*/
        //StartCoroutine(moveAvatar());

        //Debug.Log("controller.transform.position= "+ controller.transform.position);
        //controller.transform.position = new Vector3(263f, 104f, 211f);

        //------
        Debug.Log("transform.position = " + transform.position);
        //transform.position = transform.position +  transform.position;
        //------

        //transform.position = new Vector3(263f, 104f, 211f);



    }

    /*     IEnumerator moveAvatar(){
            yield return new WaitForSeconds(5);
            transform.position = new Vector3(263f, 104f, 211f);
            Debug.Log("moveAvatar");
        } */


    /*   public void pullAvatarFromWatar(){ ////////////////////
          transform.position = new Vector3(263f, 104f, 211f);
          Debug.Log("pullAvatarFromWatar////");

      } */



    public void ChangeSpeed(float speedV)
    {
        /* To Change the avatar's speed */
        anim.speed = speedV;
        Debug.Log("desiredSpeed: " + speedV);
        SSTools.ShowMessage(System.Uri.UnescapeDataString("Speed: " + speedV), SSTools.Position.bottom, SSTools.Time.twoSecond);

    }
}
