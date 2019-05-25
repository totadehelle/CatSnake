using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

public class SceneLoader : MonoBehaviour
{
    private Button btn = null;
    [SerializeField]
    private SceneField Scene;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnCLick);
    }

    void OnCLick()
    {
        SceneManager.LoadScene(Scene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
