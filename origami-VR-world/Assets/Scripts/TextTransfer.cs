using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SocketIO;

public class TextTransfer : MonoBehaviour
{
    public static Dictionary<string, string> gameDetails = new Dictionary<string, string>();
    public Text playerName_tbox;
    public Text gameCode_tbox;
    public GameObject storeCode_btn;
    /* SocketIO */
    public SocketIOComponent socket; // connect unity to nodeJS server

    void Start(){
        //Debug.Log("start fomr text trasnfer!!");
        socket.On("checkRoomExistance", GetRoomStatus);
    }

    public void StoreCode(){

        //Temp
        //Debug.Log("StoreCode: Clicked/////");

        socket.Emit("checkRoomExistance", new JSONObject("{\"gameCode\": \""+gameCode_tbox.text.ToString()+"\"}"));
    }

    // Check if room already created 
    public void GetRoomStatus(SocketIOEvent e){
        //Debug.Log("RoomStatus:b=  "+ System.Convert.ToBoolean(e.data["RoomStatus"].ToString()));

        if(System.Convert.ToBoolean(e.data["RoomStatus"].ToString())){ // if true allow user to join the game
            gameDetails["gameCode"] = gameCode_tbox.text.ToString();
            gameDetails["playerName"] = playerName_tbox.text.ToString();
            //Debug.Log("gameCode_tbox: "+ gameDetails["gameCode"]);
            //Debug.Log("Name_tbox: "+ gameDetails["gameCode"]);
            // Move to game play scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else { // if false, show a notificatoin that game is not yet created
            //Debug.Log("Room doesn't exist!!!, RoomStatus: "+e.data["RoomStatus"]);
            SSTools.ShowMessage("Game code is not correct!", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }

    }

}
