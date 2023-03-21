using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuLevel : MonoBehaviour
    {
        private string currentSceneName;
        private void Start()
        {
            currentSceneName = SceneManager.GetActiveScene().name;
        }
        public void Restart()
        {
            SceneManager.LoadScene(currentSceneName);
        }
    }
