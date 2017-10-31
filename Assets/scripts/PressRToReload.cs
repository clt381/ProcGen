using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressRToReload : MonoBehaviour {

    //Scene currentScene;
    public GameObject pathmakerPrefab;
    public Transform spawnPoint;
    public static GameObject[] floors;
    public Pathmaker pathMaker;
    public FloorController fController;

	void Start () {
        //currentScene = SceneManager.GetActiveScene();
        fController = GameObject.FindGameObjectWithTag("FloorController").GetComponent<FloorController>();
	}
	
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //SceneManager.LoadScene(currentScene.name);
            //Debug.Log("loaded");
            floors = GameObject.FindGameObjectsWithTag("Ground");
            foreach (GameObject floor in floors)
            {
                Destroy(floor.gameObject);
                Debug.Log("gameobjects destroyed");
            }
            //Invoke("SpawnPathMaker", 0.1f);
            //Instantiate(pathmakerPrefab, spawnPoint.position, spawnPoint.rotation);
            fController.counter = 0;
            StartCoroutine(SpawnPathMaker());
        }
	}

    IEnumerator SpawnPathMaker()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(pathmakerPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("loaded");
    }
}
