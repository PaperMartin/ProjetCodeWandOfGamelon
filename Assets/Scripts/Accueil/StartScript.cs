using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public BackgroundScript masterScript;
    public GameObject caméra;

    private AngelActions _angelActions;

    public Animator anim;

    private bool canStart;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        _angelActions.Base.MenuAction.performed += _ => StartGame();

    }

    private void OnDisable()
    {
        _angelActions.Disable();
    }

    private void OnEnable()
    {
        _angelActions.Enable();
    }

    private void Awake()
    {
        _angelActions = new AngelActions();
        canStart = false;
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if(caméra.transform.position == masterScript.goalPos)
        {
            anim.SetTrigger("Arrivé");

            canStart = true;
        }
    }

    public void StartGame()
    {
        if (canStart)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
