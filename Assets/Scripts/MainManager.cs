using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MainManager : MonoBehaviour {
    
    public static MainManager Instance;

    public Color teamColor;

    private void Awake() {
        
        if (Instance != null) {
            Destroy(this.gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(this);
    }
}