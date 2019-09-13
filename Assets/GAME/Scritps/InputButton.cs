using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputButton : MonoBehaviour
{
  public enum Button
    {
        left,
        right
    }

    public Button button;

    public delegate void ButtonPressed();
    public static event ButtonPressed OnLeft;
    public static event ButtonPressed OnRight;
    
    
    private void OnMouseDown()
    {
        if(OnLeft != null && button == Button.left)
        {
            Debug.Log("left");
            OnLeft();
        }else if(OnRight != null && button == Button.right)
            {
            Debug.Log("right");
            OnRight();
        }
    }
}
