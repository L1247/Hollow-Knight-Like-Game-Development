using UnityEngine;
using System.Collections;


public enum _2D_Collider_Type
{
	Box , Circle , Edge ,
	Polygon
}

/// <summary>
/// Show_s 2D colliders in scene and game(enable gizmo) view , without selecting them. High Customizable Component.
/// </summary>
[ExecuteInEditMode()]
public class Show_2D_Collider : MonoBehaviour
{
	[Space(15)]
	
	[SerializeField()]
	bool show = true;
	[SerializeField()]
	bool volume = true;
	[SerializeField()]
	_2D_Collider_Type Collider_Type = _2D_Collider_Type.Box;
	[SerializeField()]
	Color static_color = new Color (0,1,0,0.3f);

	[Space(20)]

	[SerializeField()]
	bool color_in_collision = true;
	[SerializeField()]
	Color collision_color = new Color (1,0,0,0.3f);
	
	
	[SerializeField()]
	[HideInInspector()]
	Transform trans;
	
	
	bool in_collision;
	
	
	
	
	
	
	
	
	#if UNITY_EDITOR
	
	void OnEnable () 
	{
		if(trans == null)
			trans = transform;
	}
	
	
	
	// triggers
	void OnTriggerEnter2D()
	{
		in_collision = true;
	}
	void OnTriggerStay2D()
	{
		in_collision = true;
	}
	void OnTriggerExit2D()
	{
		in_collision = false;
	}
	
	// collisions
	void OnCollisionEnter2D()
	{
		in_collision = true;
	}
	void OnCollisionStay2D()
	{
		in_collision = true;
	}
	void OnCollisionExit2D()
	{
		in_collision = false;
	}
	
	
	
	
	
	[UnityEditor.MenuItem("Tools/2DColliderPRO/Show 2D Collider" , false , 0)]
	static void Add_Show_Collider()
	{

		if (UnityEditor.Selection.gameObjects.Length != 0)
		{
			if(UnityEditor.Selection.gameObjects.Length == 1)
			{
				if (UnityEditor.Selection.activeGameObject.GetComponent<Collider2D> () != null)
				{
					Show_2D_Collider show_coll = UnityEditor.Selection.activeGameObject.AddComponent<Show_2D_Collider> ();
					if(show_coll.GetComponent<BoxCollider2D>() != null)
						show_coll.Collider_Type = _2D_Collider_Type.Box;
					if(show_coll.GetComponent<CircleCollider2D>() != null)
						show_coll.Collider_Type = _2D_Collider_Type.Circle;
					if(show_coll.GetComponent<EdgeCollider2D>() != null)
						show_coll.Collider_Type = _2D_Collider_Type.Edge;
					if(show_coll.GetComponent<PolygonCollider2D>() != null)
						show_coll.Collider_Type = _2D_Collider_Type.Polygon;
				}
				else Debug.Log("Selected gameobject does not have any 2D Collider");
			}
			else
			{
				int k = 0;
				foreach (GameObject item in UnityEditor.Selection.gameObjects)
				{
					if(item.GetComponent<Collider2D> () != null)
					{
						Show_2D_Collider show_coll = item.AddComponent<Show_2D_Collider> ();
						//Collider2D col2D = item.GetComponent<Collider2D> ();

						if(item.GetComponent<BoxCollider2D>() != null)
							show_coll.Collider_Type = _2D_Collider_Type.Box;
						if(item.GetComponent<CircleCollider2D>() != null)
							show_coll.Collider_Type = _2D_Collider_Type.Circle;
						if(item.GetComponent<EdgeCollider2D>() != null)
							show_coll.Collider_Type = _2D_Collider_Type.Edge;
						if(item.GetComponent<PolygonCollider2D>() != null)
							show_coll.Collider_Type = _2D_Collider_Type.Polygon;
					}
					else k++;
				}
				if(k > 0)
					Debug.Log(k.ToString() + " of your selected gameobjects does not have any 2D Collider");
			}

		}
		else Debug.Log("Select any gameobject(s) that have 2D Collider");
	}
	
	
	
	
	
	
	void OnDrawGizmos()
	{
		if(!show)
			return;
		
		// color region
		Color c = static_color;
		if (in_collision && color_in_collision)
			c = collision_color;
		
		
		switch(Collider_Type)
		{
				// Draw box
			case _2D_Collider_Type.Box:
				BoxCollider2D b2D = GetComponent<BoxCollider2D>();
				if(b2D == null)
					return;
				Vector3[] vb1 = new Vector3[4];
				Vector3[] vb2 = new Vector3[5];
				vb2[0]=vb2[4]=vb1[0] = trans.TransformPoint(new Vector3(b2D.offset.x - b2D.size.x/2 , b2D.offset.y - b2D.size.y/2 , trans.position.z));
				vb2[1]=vb1[1] = trans.TransformPoint(new Vector3(b2D.offset.x + b2D.size.x/2 , b2D.offset.y - b2D.size.y/2 , trans.position.z));
				vb2[2]=vb1[2] = trans.TransformPoint(new Vector3(b2D.offset.x + b2D.size.x/2 , b2D.offset.y + b2D.size.y/2 , trans.position.z));
				vb2[3]=vb1[3] = trans.TransformPoint(new Vector3(b2D.offset.x - b2D.size.x/2 , b2D.offset.y + b2D.size.y/2 , trans.position.z));
				UnityEditor.Handles.color = /*Color.green*/c;
				UnityEditor.Handles.DrawPolyLine(vb2);
				UnityEditor.Handles.color = c;
				if(volume)
					UnityEditor.Handles.DrawAAConvexPolygon(vb1);
				break;
				
				// Draw Circle
			case _2D_Collider_Type.Circle:
				CircleCollider2D c2D = GetComponent<CircleCollider2D>();
				if(c2D == null)
					return;
				float c_radius = c2D.radius * transform.lossyScale.x;
				Vector3 c_offset = transform.TransformPoint (c2D.offset);
				UnityEditor.Handles.color = Color.green;
				UnityEditor.Handles.DrawWireDisc(c_offset, Vector3.forward , c_radius);
				UnityEditor.Handles.color = new Color(c.r,c.g,c.b,c.a/2.5f);
				if(volume)
					UnityEditor.Handles.DrawSolidDisc(c_offset, Vector3.forward , c_radius);
				break;
				
				// Draw Edge
			case _2D_Collider_Type.Edge:
				EdgeCollider2D e2D = GetComponent<EdgeCollider2D>();
				if(e2D == null)
					return;
				Vector3[] ve = new Vector3[e2D.points.Length];
				for (int i = 0; i < ve.Length; i++)
					ve[i] = trans.TransformPoint(e2D.points[i]);
				UnityEditor.Handles.color = new Color(c.r,c.g,c.b,1);
				UnityEditor.Handles.DrawPolyLine(ve);
				break;
				
				// Draw Polygon
			case _2D_Collider_Type.Polygon:
				PolygonCollider2D p2D = GetComponent<PolygonCollider2D>();
				if(p2D == null)
					return;
				Vector3[] vp1 = new Vector3[p2D.points.Length];
				Vector3[] vp2 = new Vector3[p2D.points.Length+1];
				for (int i = 0; i < vp1.Length; i++)
					vp2[i] = vp1[i] = trans.TransformPoint(p2D.points[i]);
				vp2[vp1.Length] = vp2[0];
				UnityEditor.Handles.color = Color.green;
				UnityEditor.Handles.DrawPolyLine(vp2);
				UnityEditor.Handles.color = c;
				if(volume)
					UnityEditor.Handles.DrawAAConvexPolygon(vp1);
				break;
				
		}
		
		
	}

	public void SetShow(bool usingShow)
	{
		show = usingShow;
	}
	public void SetVolume(bool usingVolume)
	{
		volume = usingVolume;
	}

	public void SetType(_2D_Collider_Type type)
	{
		Collider_Type = type;
	}
	public void SetStaticColor(Color color)
	{
		static_color = color;
	}
	public void SetColorInCollision(bool color_in_collision)
	{
		this.color_in_collision = color_in_collision;
	}
	public void SetCollisionColor(Color color)
	{
		collision_color = color;
	}
	#endif
	
}
