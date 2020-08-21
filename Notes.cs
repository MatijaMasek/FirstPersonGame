using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject[] notes;
    [SerializeField] LayerMask notesMask;
    [SerializeField] float range = 3f;

    public static bool noteActive = false;

    Vector3 mousePosition;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {

            if(noteActive)
            {
                Resume();
            }

            else
            {
                if (Physics.Raycast(ray, out hit, range, notesMask))
                {

                    if (hit.transform.CompareTag("Note1"))
                    {
                        VisibleNotes(true, false, false, false, false, false);
                        ActivatePanel();

                    }

                    if (hit.transform.CompareTag("Note2"))
                    {
                        VisibleNotes(false, true, false, false, false, false);
                        ActivatePanel();

                    }

                    if (hit.transform.CompareTag("Note3"))
                    {
                        VisibleNotes(false, false, true, false, false, false);
                        ActivatePanel();

                    }

                    if (hit.transform.CompareTag("Note4"))
                    {
                        VisibleNotes(false, false, false, true, false, false);
                        ActivatePanel();

                    }

                    if (hit.transform.CompareTag("Note5"))
                    {
                        VisibleNotes(false, false, false, false, true, false);
                        ActivatePanel();

                    }

                    if (hit.transform.CompareTag("Note6"))
                    {
                        VisibleNotes(false, false, false, false, false, true);
                        ActivatePanel();

                    }
                }
            }          
        }
    }

    void ActivatePanel()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        noteActive = true;
    }

    void VisibleNotes(bool Note1, bool Note2, bool Note3, bool Note4, bool Note5, bool Note6)
    {
        notes[0].SetActive(Note1);
        notes[1].SetActive(Note2);
        notes[2].SetActive(Note3);
        notes[3].SetActive(Note4);
        notes[4].SetActive(Note5);
        notes[5].SetActive(Note6);
    }


    void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        noteActive = false;
    }
}
