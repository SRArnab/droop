using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	public void click()
	{
		SceneManager.LoadScene("Level_1");
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
