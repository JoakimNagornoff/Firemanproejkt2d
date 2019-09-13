using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{
    public delegate void Jumper();
    public static event Jumper OnJumperCrashed;
    public static event Jumper OnJumperSaved;


    [SerializeField]
    private List<Transform> positions = new List<Transform>();
    public int currentPosition = 0;

    float lastMovetime;
    float moveDelay = 1.0f;
    float deathDelay = 0.5f;

    private bool dead = false;

    public LayerMask layerMask;

    public static Action OnJumperCrash { get; internal set; }

    void Start()
    {
        UpdatePosition();
        lastMovetime = Time.time;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (!dead)
        {
            yield return new WaitForSeconds(moveDelay);
            MoveToNextPosition();

        }
    }
    void MoveToNextPosition()
    {
        currentPosition++;
        if (currentPosition >= positions.Count)
        {
            DestroyJumper();
        }
        else
        {
            UpdatePosition();
        }
    }
    void UpdatePosition()
    {
        transform.position = positions[currentPosition].position;

       if (positions[currentPosition].gameObject.tag == "DangerPosition")
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,
                Mathf.Infinity, layerMask);
            if (hit.collider == null)
            {
                Debug.Log("crash");
                StartCoroutine(Crash());
                if (OnJumperCrashed != null)
                    OnJumperCrashed();
            }
            else
            {
                Debug.Log("Saved");
                if (OnJumperSaved != null)
                    OnJumperSaved();
            }

        } 

    }
    IEnumerator Crash()
    {
        dead = true;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(deathDelay);
       DestroyJumper();
    }
    void DestroyJumper()
    {
       GameObject parent = transform.parent.gameObject;
       Destroy(parent);
   }
}
