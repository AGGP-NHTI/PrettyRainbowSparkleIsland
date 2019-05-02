using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public bool requesttoopen = false;


    public float raiseHeight = 3f;
    public float raiseZ = 3f;
    public float speed = 3f;
    private Vector3 _closedPosition;
    public AudioClip openSound;
    public AudioClip closeSound;

    // Use this for initialization
    void Start()
    {
        _closedPosition = transform.position;
    }
     void Update()
    {
        if(requesttoopen)
        {
            Open();
        }
        else
        {
            Close();
        }
    }
    void Open()
    {
        StopCoroutine("MoveDoor");
        Vector3 endpos = _closedPosition + new Vector3(0f, raiseHeight, raiseZ);
        StartCoroutine("MoveDoor", endpos);
        //audio.PlayOneShot(openSound);
    }

    void Close()
    {
        StopCoroutine("MoveDoor");
        StartCoroutine("MoveDoor", _closedPosition);
        //audio.PlayOneShot (closeSound);
    }


    IEnumerator MoveDoor(Vector3 endPos)
    {

        float t = 0f;
        Vector3 startPos = gameObject.transform.position;

        while (gameObject.transform.position != endPos)
        {
            gameObject.transform.position = Vector3.MoveTowards(startPos, endPos, Time.deltaTime * speed);
            yield return null;
        }
    }
}
