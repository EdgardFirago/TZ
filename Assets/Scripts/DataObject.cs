using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DataObject : MonoBehaviour
{
    private ArrayList keyframes;
    private int keyframe = 5;
    private int frameCounter = 0;
    private int reverseCounter = 0;

    private Rigidbody rig;

    private Vector3 currentPosition;
    private Vector3 previousPosition;
    private Quaternion currentRotation;
    private Quaternion previousRotation;


    private bool firstRun = true;

    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody>();
        keyframes = new ArrayList();
    }



    void FixedUpdate()
    {
        if (!ObjectController.GetRest)
        {
            
            if (frameCounter < keyframe)
            {
                frameCounter += 1;
            }
            else
            {
                frameCounter = 0;
                keyframes.Add(new Keyframe(this.gameObject.transform.position, this.gameObject.transform.rotation));
                
          }
        }
        else
        {
            
            if (reverseCounter > 0)
            {
                reverseCounter -= 1;
            }
            else
            {
                reverseCounter = keyframe;
                RestorePositions();
            }

            float interpolation = (float)reverseCounter / (float)keyframe;
            this.gameObject.transform.position = Vector3.Lerp(previousPosition, currentPosition, interpolation);
            this.gameObject.transform.rotation = Quaternion.Lerp(previousRotation, currentRotation, interpolation);
        }


    }

    void RestorePositions()
    {
        int lastIndex = keyframes.Count - 1;
        int secondToLastIndex = keyframes.Count - 2;

        if (secondToLastIndex >= 0)
        {
            currentPosition = (keyframes[lastIndex] as Keyframe).position;
            previousPosition = (keyframes[secondToLastIndex] as Keyframe).position;

            currentRotation = (keyframes[lastIndex] as Keyframe).rotation;
            previousRotation = (keyframes[secondToLastIndex] as Keyframe).rotation;

            keyframes.RemoveAt(lastIndex);
        }
    }
}


