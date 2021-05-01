using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    public string SceneName;
    public GameObject Character;
    public Animator animator;
    public Animator fade;
    public GameObject Character_cam;

    private bool walk;
    private void Update()
    {
        if (walk)
        {
            Vector3 horizontal = new Vector3(1f, 0.0f, 0.0f);
            Character.transform.position = Character.transform.position + horizontal * Time.deltaTime*3;
        }
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        StartCoroutine("ChangeScene");
    }
    IEnumerator ChangeScene()
    {
        //change camera
        Character_cam.SetActive(false);
        //move character
        animator.SetTrigger("Ending");
        walk = true;
        FindObjectOfType<SimpleMovement>().enabled = false;
        //fade in
        fade.SetTrigger("out");
        yield return new WaitForSeconds(1f);
        //change scene
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);

    }
  
}
