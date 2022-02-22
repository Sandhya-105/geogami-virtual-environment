#if ENABLE_INPUT_SYSTEM 
using UnityEngine.InputSystem;
#endif

using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; // Stope cursor
        //Cursor. visible = false;
    }

    void OnGUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Exit Sample  

            if (IsEscapePressed())
            {
                Application.Quit();
				#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false; 
				#endif
            }
        
    }

    bool IsEscapePressed()
        {
            #if ENABLE_INPUT_SYSTEM
                        return Keyboard.current != null ? Keyboard.current.escapeKey.isPressed : false; 
            #else
                        return Input.GetKey(KeyCode.Escape);
            #endif
        }
}
