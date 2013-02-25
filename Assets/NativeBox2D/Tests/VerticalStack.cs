


using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

public class VerticalStack : Testbed {
	
	IntPtr m_body;
	public int e_columnCount = 5;
	public int e_rowCount = 16;
	
	// Use this for initialization
	protected override void Init () {
		var ground = API.CreateBody(world, new Vector2(0,0), 0, BodyType.STATIC_BODY );
		API.AddEdgeShape(ground, new Vector2(-40.0f,0.0f), new Vector2(40.0f,0.0f), new ShapeDef(0));
		API.AddEdgeShape(ground, new Vector2(20.0f,0.0f), new Vector2(20.0f,20.0f), new ShapeDef(0));
		

		float[] xs = new float[5] {0.0f, -10.0f, -5.0f, 5.0f, 10.0f};
		
		ShapeDef sp = new ShapeDef(1.0f);
		sp.friction = 0.3f;
		
		for (int j = 0; j < e_columnCount; ++j)
		{
			for (int i = 0; i < e_rowCount; ++i)
			{
				var b = API.CreateBody( world, new Vector2(xs[j], 0.752f + 1.54f * i), 0, BodyType.DYNAMIC_BODY );
				API.AddBoxShape(b, 0.5f, 0.5f, Vector2.zero,0,sp);
			}
		}
	}
}
