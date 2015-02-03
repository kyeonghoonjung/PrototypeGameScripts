using UnityEngine;
using System.Collections;

public class LinesHandler : MonoBehaviour
{
	public Color c1 = Color.red;
	public Color c2 = Color.red;
	
	private GameObject lineGO;
	private LineRenderer lineRenderer;
	private int i = 0;

	//Comment
	void Start()
	{
		lineGO = new GameObject("Line");
		lineGO.AddComponent<LineRenderer>();
		lineGO.AddComponent<Rigidbody> ();
		lineGO.transform.position.Set (0, 0, 15);
		lineRenderer = lineGO.GetComponent<LineRenderer>();
		//lineRenderer.material = new Material(Shader.Instantiate(
		lineRenderer.SetColors(c1, c2);
		lineRenderer.SetWidth(0.3F, 0);
		lineRenderer.SetVertexCount(0);

	}
	
	void Update()
	{

			if (Input.GetMouseButtonUp(0)) {
				//Debug.Log("button up");	
				
				lineRenderer.SetVertexCount(0);
				i = 0;
				
				BoxCollider[] lineColliders = lineGO.GetComponents<BoxCollider>();
				
				foreach(BoxCollider b in lineColliders)
				{
					Destroy(b);
				} 
			} else if (Input.GetMouseButton (0))  {
				//Debug.Log("Button down");
				lineRenderer.SetVertexCount(i+1);
				Vector3 mPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15);
				lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(mPosition));
				i++;
				
				BoxCollider bc = lineGO.AddComponent<BoxCollider>();
				bc.transform.position = new Vector3(lineRenderer.transform.position.x, lineRenderer.transform.position.y, 15);
				bc.size.Set(5f, 5f, 5f);

				
			}


		/* if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			
			if(touch.phase == TouchPhase.Moved)
			{
				lineRenderer.SetVertexCount(i+1);
				Vector3 mPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15);
				lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(mPosition));
				i++;
				

				BoxCollider bc = lineGO.AddComponent<BoxCollider>();
				bc.transform.position = lineRenderer.transform.position;
				bc.size = new Vector3(0.1f, 0.1f, 0.1f);
			}
			
			if(touch.phase == TouchPhase.Ended)
			{

				lineRenderer.SetVertexCount(0);
				i = 0;

				
				BoxCollider[] lineColliders = lineGO.GetComponents<BoxCollider>();
				
				foreach(BoxCollider b in lineColliders)
				{
					Destroy(b);
				}
			}
		} */
	}
}
