using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour 
{
    public delegate void HandleTouchInput(Touch _touch, int _fingerId);
    public static event HandleTouchInput handleTouchInput;

    public delegate void HandleMouseInput(Vector3 _mousePixPos, bool _mouseDown, bool _mouseUp, int _playerId);
    public static event HandleMouseInput handleMouseInput;

    public static Vector3 ppTouchPos;
    public static Vector3 wpTouchPos;


    private void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        MouseInput();
#else
        TouchInput();
#endif
    }

//#if UNITY_EDITOR //|| UNITY_STANDALONE_WIN
    private void MouseInput()
    {
        var mousePosition = Input.mousePosition;
        var id = mousePosition.y < Screen.height / 2f ? 0 : 1;

        if(handleMouseInput != null)
            handleMouseInput(mousePosition, Input.GetMouseButton(0), Input.GetMouseButtonUp(0), id);

        ppTouchPos = mousePosition;
        wpTouchPos = Camera.main.ScreenToWorldPoint(ppTouchPos);
    }

    //#else

    private void TouchInput()
    {
        if(Input.touchCount <= 0)
            return;

        for(int i = 0; i < Input.touches.Length; i++)
        {
            var touch = Input.touches[i];
            var id = touch.position.y < Screen.height / 2f ? 0 : 1;

            if(handleTouchInput != null)
                handleTouchInput(touch, id);

            ppTouchPos = touch.position;
            wpTouchPos = Camera.main.ScreenToWorldPoint(ppTouchPos);

            var output = "";
            switch(touch.phase)
            {
                case TouchPhase.Began:
                    output = "Touch Began";
                    break;
                case TouchPhase.Moved:
                    output = "Touch Moved";
                    break;
                case TouchPhase.Ended:
                    output = "Touch Ended";
                    break;
                default:
                    output = "Touch None";
                    break;
            }
            Debug.Log(output);
        }
    }
//#endif
}
