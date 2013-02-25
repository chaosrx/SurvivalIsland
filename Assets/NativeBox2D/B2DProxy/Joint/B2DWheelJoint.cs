using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;


[AddComponentMenu("NativeBox2D/Joints/WheelJoint")]
public class B2DWheelJoint : B2DJoint {

    public Vector3 anchor;
    public Vector3 axis = Vector3.right;
			
	public bool enableMotor;
	public float maxMotorTorque;
	public float motorSpeed;
	public float frequencyHz = 2.0f;
	public float dampingRatio = 0.7f;

    // Use this for initialization
    protected override IntPtr Init()
    {
		WheelJointDef jd = new WheelJointDef(other.body, body.body);
		jd.Initialize(other.body,body.body,anchor, axis);
		jd.enableMotor = enableMotor;
		jd.maxMotorTorque = maxMotorTorque;
		jd.motorSpeed = motorSpeed;
		jd.frequencyHz = frequencyHz;
		jd.dampingRatio = dampingRatio;
        return API.CreateWheelJoint( B2DWorld.instance.world, jd );
    }
}
