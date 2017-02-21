using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour {

	GameObject clickedGameObject;

	// Update is called once per frame
	void Update () {

		//Is the mouse over a Unity UI Element?
		if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject ()) {
			return;
		}

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;

		if(Physics.Raycast(ray, out hitInfo)){
			
			GameObject hitObject = hitInfo.collider.transform.parent.gameObject;

			if(hitObject.GetComponent<Hex>() != null){
				mouseOverTile (hitObject);
			}

			if (hitObject.GetComponent<EnemyUnit> () != null) {
				mouseOverEnemy (hitObject);
			}
		}
	
	}

	private void mouseOverTile(GameObject hitObject){

		if(Input.GetMouseButtonDown(0)){
			clickedGameObject = hitObject;
		}

		if (Input.GetMouseButtonUp (0)) {
			hitObject.GetComponent<Hex>().selectTile ();
		}
	}


	private void mouseOverEnemy(GameObject hitObject){
		Debug.Log ("**************666*****************");
		if(Input.GetMouseButtonDown(0)){
			clickedGameObject = hitObject;
			hitObject.GetComponentInChildren<Transform> ().Rotate (new Vector3 (0, 80, 0));
		}

		if (Input.GetMouseButtonUp (0)) {
			
		}

	}

}
