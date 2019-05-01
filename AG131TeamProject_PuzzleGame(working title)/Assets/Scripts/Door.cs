using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{

    public Transform doorTransform;
    public float raiseHeight = 3f;
    public float speed = 3f;
    private Vector3 _closedPosition;
    public AudioClip openSound;
    public AudioClip closeSound;

    // Use this for initialization
    void Start()
    {
        _closedPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        StopCoroutine("MoveDoor");
        Vector3 endpos = _closedPosition + new Vector3(0f, raiseHeight, 0f);
        StartCoroutine("MoveDoor", endpos);
        //audio.PlayOneShot(openSound);
    }

    void OnTriggerExit(Collider other)
    {
        StopCoroutine("MoveDoor");
        StartCoroutine("MoveDoor", _closedPosition);
        //audio.PlayOneShot (closeSound);
    }


    IEnumerator MoveDoor(Vector3 endPos)
    {

        float t = 0f;
        Vector3 startPos = doorTransform.position;

        while (doorTransform.position != endPos)
        {
            doorTransform.position = Vector3.MoveTowards(startPos, endPos, Time.deltaTime * speed);
            yield return null;
        }
    }
}
