using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Camera playerCam;
    public int playerNumber;
    public float speed;

  /*  private Rigidbody paddleRigidbody;
    public Transform targetTr;
    private RaycastHit hit;
    // LayerMask is used in the rayCast, to raycast for layer 8, "InputRaycast Layer". raycast is used to determine player movement.
    public LayerMask layerMask = 1 << 8;
    // the ray hit position relative to the zone's local position - this is used in "Update()" function to move mallet's target ("TargetTr")
    private Vector3 hitPosRelativeToZoneSpace; // = Vector3 (0, 0, 1);
                                               // The mallet's side zone - It's also the parent of the gameObject
    public GameObject zone;*/

    // Use this for initialization
    void Start()
    {
        Debug.Log("Here");
       // paddleRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    /*  void Update()
      {
          float horizontalMovement = Input.GetAxis("Horizontal" + playerNumber) * speed;
          float verticalMovement = Input.GetAxis("Vertical" + playerNumber) * speed;

          paddleRigidbody.velocity = new Vector3(horizontalMovement, 0, verticalMovement);
      }

      void Update()
      {
              /*int i = 0;
              while (i < Input.touchCount) //for (Touch touch in Input.touches)
              {
                  // Construct a ray from the current touch coordinates
                  Ray mousePosRay = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                  if (Physics.Raycast(mousePosRay, out hit, 10, layerMask))
                  {
                      // Convert hit point position from world space to "zone"'s local space - so we can retrieve input positions relative to each zone
                      // We do it using "Transform.InverseTransformPoint" (see http://docs.unity3d.com/Documentation/ScriptReference/Transform.InverseTransformPoint.html)
                      hitPosRelativeToZoneSpace = zone.transform.InverseTransformPoint(hit.point);

                      // Move from "myTr" local position to "hitPosRelativeToZoneSpace" at the given speed ("targetSpeed")								
                      targetTr.localPosition = Vector3.Lerp(myTr.localPosition, new Vector3(hitPosRelativeToZoneSpace.x, targetTr.localPosition.y, hitPosRelativeToZoneSpace.z), targetSpeed * Time.fixedDeltaTime);
                  }
                  ++i;
              }
          }*/
    private void Update()
    {
        Debug.Log(Input.touchCount);
        if (Input.touchCount != 1)
            return;
       // Debug.Log("POS " + Input.touches[0].position);
        var ray = playerCam.ScreenPointToRay(Input.touches[0].position);
        var hitInfo = new RaycastHit();
      //  Debug.Log("NEW POS OLD" + transform.position);
        if (Physics.Raycast(ray, out hitInfo))
        {
            //Debug.Log("Here2");
            print(hitInfo.transform.name);
            if (hitInfo.transform.name != "Air Hockey Table")
            {
             //   return;
            }
            //Debug.Log("Here4");
            var newPos = transform.position;
            newPos.x = hitInfo.point.x;
            newPos.z = hitInfo.point.z;
            if (newPos.z > 0)
            {
                newPos.z = 0f;
            }
            newPos.y = 11.8f;
            Debug.Log("NEW POS LOC" + hitInfo.transform.name + "OLD " + transform.position + "NEW " + newPos);
            float distance = Vector2.Distance(transform.position, newPos);
            transform.position = newPos;
        }
    }
}
