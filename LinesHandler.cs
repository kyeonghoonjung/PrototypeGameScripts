using UnityEngine;
using System.Collections;

public class LinesHandler : MonoBehaviour
{
	public Color c1 = Color.yellow;
	public Color c2 = Color.red;
	
	private GameObject lineGO;
	private LineRenderer lineRenderer;
	private int i = 0;
	private RaycastHit hit;
	void Start()
	{
		lineGO = new GameObject("Line");
		lineGO.AddComponent<LineRenderer>();
		lineRenderer = lineGO.GetComponent<LineRenderer>();
		//lineRenderer.material = new Material(Shader.Find("Mobile/Particles/Additive"));
		lineRenderer.SetColors(c1, c2);
		lineRenderer.SetWidth(0.3F, 0);
		lineRenderer.SetVertexCount(0);
	}
	
	void Update()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			
			if(touch.phase == TouchPhase.Moved)
			{
				lineRenderer.SetVertexCount(i+1);
				Vector3 mPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
				lineRenderer.SetPosition(i, Camera.main.ScreenToWorldPoint(mPosition));
				i++;
				//Creating a new ray from the position of the touch.
				Ray ray = Camera.main.ScreenPointToRay (touch.position);
				
				if (Physics.Raycast(ray, out hit)) {
					Debug.Log("raycast hit!");
					//on raycast hit, checking tag of collider
					if(hit.collider.tag == "Enemy")
					{
						//calling a public function from the enemy object
						Enemy e = (Enemy)hit.collider.gameObject.GetComponent(typeof(Enemy));
						e.OnHit();
					}

				}
			}
			
			if(touch.phase == TouchPhase.Ended)
			{
				/* Remove Line */
				
				lineRenderer.SetVertexCount(0);
				i = 0;
				

			}
		}
	}
}