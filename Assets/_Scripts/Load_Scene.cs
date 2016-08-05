using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Load_Scene : MonoBehaviour {

	public int sceneIndex;
	private Color tempColor;

	void Start(){
		changeColor (Color.blue);
	}

	void OnMouseEnter(){		
		changeColor (Color.yellow);
	}

	void OnMouseExit(){		
		changeColor (Color.blue);
	}

	void changeColor(Color color){
		tempColor = gameObject.GetComponent<Renderer> ().material.color;
		tempColor = color;
		gameObject.GetComponent<Renderer> ().material.color = tempColor;
	}

	void OnMouseOver() {
		if (Input.GetKeyDown("mouse 0")){
			if (gameObject.name == ("Quit_button")){
				Application.Quit();
			}
			else{
				SceneManager.LoadScene(sceneIndex);
			}
		}
	}
}
