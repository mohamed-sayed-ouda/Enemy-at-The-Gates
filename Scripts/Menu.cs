using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    [SerializeField]
    private Text Pause;

   

    void Awake() {


	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    

    public void Ranger() {
		SceneManager.LoadScene ("Ranger");
	}
    public void Girl()
    {
        SceneManager.LoadScene("BarbrianGirl");
    }

	public void Quit() {

        UnityEditor.EditorApplication.isPlaying = false;
	}
    public void Start_Pause()
    {

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            Pause.text = "Start";
        }
        else
        {
            Time.timeScale = 1;
            Pause.text = "Pause";

        }

    }
}
