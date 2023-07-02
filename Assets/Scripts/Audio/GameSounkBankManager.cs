using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSounkBankManager : MonoBehaviour
{

    public static GameSounkBankManager instance;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}