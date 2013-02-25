using UnityEngine;
using System.Collections;

public class U3D_Rope : MonoBehaviour {

    public Rigidbody ground;
    public HingeJoint jointPref;
    public int nodeCount = 30;
    public int ropeCount = 5;

	// Use this for initialization
	IEnumerator Start () {
        for (int i = 0; i < ropeCount; ++i)
        {
            Transform ropeTrans = new GameObject("Rope" + i).transform;
            ropeTrans.parent = transform;
            ropeTrans.localPosition = Vector3.zero;
            Rigidbody prev = ground;
            for (int j = 0; j < nodeCount; ++j)
            {
                HingeJoint rj = (HingeJoint)Instantiate(jointPref, transform.position + new Vector3(-20 + i * 10, 10 - 1.2f * j, 0), Quaternion.identity);
                rj.connectedBody = prev;
                rj.transform.parent = ropeTrans;
                //rj.transform.localPosition = new Vector3(-20 + i * 10, 10 - 1.2f * j, 0);
                prev = rj.rigidbody;
            }

            yield return 0;

            prev.AddForce(Vector3.right * 200, ForceMode.Impulse);
            //NativeBox2D.API.ApplyLinearImpulse(prev.body, 200 * new Vector2(1, 0), Vector2.right);
        }		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
