using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiremanController : MonoBehaviour
{


    public List<Transform> positions = new List<Transform>();

    private int currentPosition = 1;
    private void OnEnable()
    {
        InputButton.OnLeft += OnLeftPressed;
        InputButton.OnRight += OnRightPressed;
    }

    private void OnDisable()
    {
        InputButton.OnLeft -= OnLeftPressed;
        InputButton.OnRight -= OnRightPressed;
    }
    private void Start()
    {
        UpDatePosition();
    }

    private void OnLeftPressed()
    {
        if(currentPosition > 0)
        {
            currentPosition--;
            UpDatePosition();
        }

    }

     private void OnRightPressed()
    {
        if(currentPosition < positions.Count -1)
        {
            currentPosition++;
            UpDatePosition();
        }

    }
    private void UpDatePosition()
    {
        transform.position = positions[currentPosition].position;

    }
}
