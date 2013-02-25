using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

[AddComponentMenu("NativeBox2D/Body")]
public class B2DBody : MonoBehaviour {

	public BodyType type = BodyType.STATIC_BODY;
	public Vector2 linearVelocity;
	public float angularVelocity;
	public float linearDamping;
	public float angularDamping;
	public bool allowSleep = true;
	public bool awake = true;
	public bool fixedRotation;
	public bool bullet;
	public bool active = true;
	//public int userData;
	public float gravityScale = 1;

    [HideInInspector]
    public IntPtr body;

    public bool Started { get { return started; } }
    bool started = false;

    Transform myTrans;	
	// Use this for initialization
	void Awake () {
        myTrans = transform;
	}

    public void Start()
    {
        if (!started)
        {
            started = true;
			  
			BodyDef def = new BodyDef( type );
			def.position = transform.position;
			def.angle = transform.localEulerAngles.z*Mathf.Deg2Rad;
			def.linearVelocity = linearVelocity;
			def.angularVelocity = angularVelocity;
			def.linearDamping = linearDamping;
			def.angularDamping = angularDamping;
			def.allowSleep = allowSleep;
			def.awake = awake;
			def.fixedRotation = fixedRotation;
			def.bullet = bullet;
			def.active = active;
			def.userData = 0;
			def.gravityScale = gravityScale;

            body = API.CreateBody(B2DWorld.instance.world, def);
        }
    }

    void OnDestroy()
    {
		if( body != IntPtr.Zero && B2DWorld.instance.world != IntPtr.Zero )
		{
			API.DestroyBody(B2DWorld.instance.world, body);
			body = IntPtr.Zero;
		}
    }

	// Update is called once per frame
	void FixedUpdate () {
        Vector2 pos;
        API.GetPosition(body, out pos);
        float angle = API.GetAngle(body);
        myTrans.position = pos;
        myTrans.eulerAngles = new Vector3(0, 0, angle*Mathf.Rad2Deg);
	}
}
