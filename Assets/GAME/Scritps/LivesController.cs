using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    public float distance = 1.0f;
    private List<GameObject> lives = new List<GameObject>();

    public void InitLives(int count)
    {
        GameObject firstLive = transform.GetChild(0).gameObject;
        lives.Add(firstLive);
   
   
    for(int i = 0; i < count - 1; i++)
        {
        GameObject live = Instantiate(firstLive);
        lives.Add(live);
        live.transform.parent = transform;
        Vector3 pos = live.transform.position;
        pos.x += distance * (i+1);
        live.transform.position = pos;
        }

}
    public bool RemoveLife()
    {
        Debug.Log("die");
        if(lives.Count < 1)
        {
            return false;
        }
        GameObject lastLive = lives[lives.Count - 1];
        lives.RemoveAt(lives.Count - 1);

        Destroy(lastLive);
        return true;
    }



   
}
