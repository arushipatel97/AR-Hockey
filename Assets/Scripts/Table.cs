using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class Table : MonoBehaviour
{
    public GameObject anchoredPrefab;
//    public GameObject unanchoredPrefab;

    Anchor anchor;
    Vector3 lastAnchorPosition;
    Quaternion lastAnchorRotation;
    private void Start()
    {
        Debug.Log("HERE");
        Pose pose = new Pose(transform.position, transform.rotation);
        anchor = Session.CreateAnchor(pose);
        Debug.Log("HERE1");
        GameObject.Instantiate(anchoredPrefab, anchor.transform.position, anchor.transform.rotation, anchor.transform);
        // GameObject.Instantiate(unanchoredPrefab, anchor.transform.position, anchor.transform.rotation);
        Debug.Log("HERE2");
        lastAnchorPosition = anchor.transform.position;
        lastAnchorRotation = anchor.transform.rotation;
        Debug.Log("last position" + lastAnchorPosition);
    }

    // Update is called once per frame
    /*void Update()
    {
        if (count == 0)
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                Debug.Log("got touch");
                Pose pose = new Pose(transform.position, transform.rotation);
                anchor = Session.CreateAnchor(pose);
                GameObject.Instantiate(anchoredPrefab, anchor.transform.position, anchor.transform.rotation, anchor.transform);
                // GameObject.Instantiate(unanchoredPrefab, anchor.transform.position, anchor.transform.rotation);
                lastAnchorPosition = anchor.transform.position;
                lastAnchorRotation = anchor.transform.rotation;
                Debug.Log("last position" + lastAnchorPosition);
            }

            if (anchor == null)
            {
                return;
            }

            if (anchor.transform.position != lastAnchorPosition)
            {
                Debug.Log(Vector3.Distance(anchor.transform.position, lastAnchorPosition));
                lastAnchorPosition = anchor.transform.position;
            }

            if (anchor.transform.rotation != lastAnchorRotation)
            {
                Debug.Log(Quaternion.Angle(anchor.transform.rotation, lastAnchorRotation));
                lastAnchorRotation = anchor.transform.rotation;
            }
            count = 1;
        }

    }*/
}