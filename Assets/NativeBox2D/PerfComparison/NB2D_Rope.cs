using UnityEngine;
using System.Collections;

public class NB2D_Rope : MonoBehaviour {

    public B2DBody ground;
    public B2DRevoluteJoint jointPref;
    public int nodeCount = 30;
    public int ropeCount = 5;
	// Use this for initialization
    IEnumerator Start()
    {
        for (int i = 0; i < ropeCount; ++i)
        {
            Transform ropeTrans = new GameObject("Rope" + i).transform;
            ropeTrans.parent = transform;
            ropeTrans.localPosition = Vector3.zero;
            B2DBody prev = ground;
            for (int j = 0; j < nodeCount; ++j)
            {
                B2DRevoluteJoint rj = (B2DRevoluteJoint)Instantiate(jointPref);
                rj.transform.parent = ropeTrans;
                rj.transform.localPosition = new Vector3(-20 + i * 10, 10 - 1.2f*j, 0);
                rj.other = prev;
                rj.anchor = new Vector3(-20 + i * 10, 11 - 1.2f*j, 0);
                prev = rj.body;
            }

            yield return 0;

            NativeBox2D.API.ApplyLinearImpulse(prev.body, 200 * new Vector2(1, 0), Vector2.right);
        }

    }

    // Update is called once per frame
    void Update()
    {
	
	}
}
