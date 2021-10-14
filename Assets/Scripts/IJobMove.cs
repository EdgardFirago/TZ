using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;

public class IJobMove : IJobParallelForTransform
{
    public NativeArray<Vector3> Positions;
    public NativeArray<Quaternion> Rotations;

    public void Execute(int index, TransformAccess transform)
    {
       
    }
}
