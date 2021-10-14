using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    private LineRenderer lineRender;
    [SerializeField] float _width = 0.1f;
    void Start()
    {
        lineRender = GetComponent<LineRenderer>();
        lineRender.startWidth = _width;
        lineRender.endWidth = _width;

    }
   public void renderTrajectory(Vector3 origin,Vector3 speed)
    {
        Vector3[] points = new Vector3[3];
        lineRender.positionCount = points.Length;
        for(int i=0;i<points.Length;i++)
        {
            float time = i * 0.1f;
            points[i] = origin + speed * time+Physics.gravity*time*time/2f;
        }

        lineRender.SetPositions(points);

    }

    public void rendereTrajectoryClear()
    {
        lineRender.positionCount = 0;
    }

    
}
