using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {

	void Update()
	{
		moveOffscreenBackgroundPaneToFront();
	}

	void moveOffscreenBackgroundPaneToFront()
	{
		int numChildren = transform.childCount;
		
		for (int i = 0; i < numChildren; i++)
		{
			GameObject pane = transform.GetChild(i).gameObject;
			
			if (checkIfOffscreen(pane))
			{
				GameObject rightMostPane = getRightMostPane();
				movePaneToRight(pane, rightMostPane);
			}
		}
	}

	bool checkIfOffscreen(GameObject pane)
	{
		Vector3 objectRightEdge = getObjectRightEdge(pane);

		if (hasObjectGoneOffScreen(objectRightEdge))
		{
			return true;
		}

		return false;
	}

	Vector3 getObjectRightEdge(GameObject obj)
	{
		Vector3 rightEdge = obj.transform.position;
		rightEdge.x += getObjectWidth(obj) * getObjectScale(obj);
		
		return rightEdge;
	}

	float getObjectWidth(GameObject obj)
	{
		return obj.collider2D.bounds.size.x;
	}

	float getObjectScale(GameObject obj)
	{
		return obj.transform.localScale.x;
	}
	
	bool hasObjectGoneOffScreen(Vector3 obj)
	{
		return Camera.main.WorldToScreenPoint(obj).x <= 0;
	}

	GameObject getRightMostPane()
	{
		float rightMostPosition = 0.0f;
		GameObject rightMostPane = null;

		try
		{
			int children = transform.childCount;

			for (int i = 0; i < children; ++i)
			{
				GameObject pane = transform.GetChild(i).gameObject;
				if (pane.transform.position.x > rightMostPosition)
				{
					rightMostPane = pane;
					rightMostPosition = rightMostPane.transform.position.x;
				}
			}

			return rightMostPane;
		}
		catch (UnityException e)
		{
			Debug.Log ("No pane found " + e);
			return null;
		}
	}

	void movePaneToRight(GameObject thisPane, GameObject rightMostPane)
	{
		Vector3 tempVector = new Vector3 (thisPane.transform.position.x, 
		                                  thisPane.transform.position.y, 
		                                  thisPane.transform.position.z);
		tempVector.x = rightMostPane.transform.position.x + getObjectWidth(rightMostPane);
		thisPane.transform.position = tempVector;
	}
}
