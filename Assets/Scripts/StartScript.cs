using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public static StartScript instance;
    public int choice = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Human()
    {
        choice = 0;
        PlayerPrefs.SetInt("choice", 0);
        //GameStartpanel.SetActive(false);
        SceneManager.LoadScene("Pong");
        Debug.Log("Human");
    }

    public void Machine()
    {
        choice = 1;
        PlayerPrefs.SetInt("choice", 1);
        //GameStartpanel.SetActive(false);
        SceneManager.LoadScene("Pong");
        Debug.Log("Machine");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
