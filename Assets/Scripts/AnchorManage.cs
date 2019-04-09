using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class AnchorManage : MonoBehaviour
{
    public GameObject anchoredPrefab;
    public GameObject unanchoredPrefab;
    int count = 0;

    Anchor anchor;
    Vector3 lastAnchorPosition;
    Quaternion lastAnchorRotation;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && count == 0)
        {
            Debug.Log("got touch");
            Vector3 pos = new Vector3(0, 0, 0);
            pos = transform.position;
            Pose pose = new Pose(pos, transform.rotation);
            anchor = Session.CreateAnchor(pose);
            transform.Rotate(90, 0, 0);
            GameObject.Instantiate(anchoredPrefab, anchor.transform.position, anchor.transform.rotation, anchor.transform);
            GameObject.Instantiate(unanchoredPrefab, anchor.transform.position, anchor.transform.rotation);
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
}