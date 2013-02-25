using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

[AddComponentMenu("NativeBox2D/Joints/RopeJoint")]
public class B2DRopeJoint : B2DJoint {

    public Vector3 archorA = new Vector3(-1.0f,0,0);
    public Vector3 archorB = new Vector3(1.0f,0,0);
    public float maxLength;

    // Use this for initialization
    protected override IntPtr Init()
    {
        Vector3 posA = transform.position + archorA;
        Vector3 posB = transform.position + archorB;
		RopeJointDef jd = new RopeJointDef(other.body, body.body);
		jd.localAnchorA = new Vector2(posA.x, posA.y);
		jd.localAnchorB = new Vector2(posB.x, posB.y);
		jd.maxLength = maxLength;
        return API.CreateRopeJoint( B2DWorld.instance.world, jd );
    }
}
