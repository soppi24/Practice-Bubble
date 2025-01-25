using UnityEngine;
using System.Collections.Generic;

public class BarController : MonoBehaviour
{
    private List<NoteController> notesInBar = new List<NoteController>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (notesInBar.Count > 0)
            {
                NoteController noteHit = notesInBar[0];
                Destroy(noteHit.gameObject);
                notesInBar.RemoveAt(0);
                Debug.Log("Note Hit!");
            }
            else
            {
                Debug.Log("No notes to hit!");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        NoteController note = other.GetComponent<NoteController>();
        if (note != null)
        {
            notesInBar.Add(note);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        NoteController note = other.GetComponent<NoteController>();
        if (note != null && notesInBar.Contains(note))
        {
            notesInBar.Remove(note);
        }
    }
}
