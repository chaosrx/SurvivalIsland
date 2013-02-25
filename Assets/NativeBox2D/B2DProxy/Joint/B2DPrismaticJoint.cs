using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

[AddComponentMenu("NativeBox2D/Joints/PrismaticJoint")]
public class B2DPrismaticJoint : B2DJoint {

    public Vector3 anchor;
    public Vector3 axis = Vector3.right;
			
	public bool enableLimit;
	public float lowerTranslation;
	public float upperTranslation;
	public bool enableMotor;
	public float maxMotorForce;
	public float motorSpeed;

    // Use this for initialization
    protected override IntPtr Init()
    {
		PrismaticJointDef jd = new PrismaticJointDef(other.body, body.body);
		jd.Initialize(other.body,body.body,anchor, axis);
		jd.enableLimit = enableLimit;
		jd.lowerTranslation = lowerTranslation;
		jd.upperTranslation = upperTranslation;
		jd.enableMotor = enableMotor;
		jd.maxMotorForce = maxMotorForce;
		jd.motorSpeed = motorSpeed;
        return API.CreatePrismaticJoint( B2DWorld.instance.world, jd );
    }
}
