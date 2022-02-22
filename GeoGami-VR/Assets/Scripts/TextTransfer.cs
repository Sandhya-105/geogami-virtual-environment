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

    // Toggle 
    //public Toggle world1_cbox;
    void Start()
    {
        //Debug.Log("on Start!!");
        socket.On("checkRoomExistance", GetRoomStatus);
    }

    public void StoreCode()
    {
        //Debug.Log("on StoreCode!!");
        socket.Emit("checkRoomExistance", new JSONObject("{\"gameCode\": \"" + gameCode_tbox.text.ToString() + "\"}"));
    }

    // Check if room already created 
    public void GetRoomStatus(SocketIOEvent e)
    {
        //Debug.Log("roomCode:b=  "+  (e.data["roomCode"].ToString()).GetType() + ", Val: "+e.data["roomCode"].ToString());
        
        // check user (this will prevent other users who are in main scene to join game with currrent room)
        if(string.Equals(e.data["roomCode"].ToString(),("\""+gameCode_tbox.text.ToString()+"\""))){
            if (System.Convert.ToBoolean(e.data["roomStatus"].ToString()))
            { // if true allow user to join the game
                gameDetails["gameCode"] = gameCode_tbox.text.ToString();
                gameDetails["playerName"] = playerName_tbox.text.ToString();
                gameDetails["vr_world_1_status"] = e.data["roomVRWorldType"].ToString();

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {   // if false, show a notificatoin that game code is not yet created
                SSTools.ShowMessage("Game code is not correct!", SSTools.Position.bottom, SSTools.Time.twoSecond);
            }
        }

    }

}
