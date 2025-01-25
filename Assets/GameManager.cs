using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource song;
    public float hitWindow = 0.2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            NoteController[] notes = FindObjectsOfType<NoteController>();
            float currentTime = song.time;

            foreach (NoteController note in notes)
            {
                if (!note.isActive) continue;

                float noteTime = note.targetTime;
                if (Mathf.Abs(noteTime - currentTime) <= hitWindow)
                {
                    note.isActive = false;
                    Destroy(note.gameObject);
                    break;
                }
            }
        }
    }
}
