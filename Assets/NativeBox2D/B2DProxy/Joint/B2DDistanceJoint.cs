using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

[AddComponentMenu("NativeBox2D/Joints/DistanceJoint")]
public class B2DDistanceJoint : B2DJoint {

    public Vector3 anchor1;
    public Vector3 anchor2;
	
	public float frequencyHz;
	public float dampingRatio;

    // Use this for initialization
    protected override IntPtr Init()
    {
		DistanceJointDef jd = new DistanceJointDef(other.body, body.body);
		jd.Initialize(other.body,body.body,anchor1, anchor2);
		jd.frequencyHz = frequencyHz;
		jd.dampingRatio = dampingRatio;
        return API.CreateDistanceJoint( B2DWorld.instance.world, jd );
    }
}
