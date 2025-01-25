using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public AudioSource song;
    public float leadInTime = 2f;
    public float moveSpeed = 5f;
    public float spawnX = -8f;

    public float[] beatTimes = { 12.267f, 13.287f, 14.314f, 14.863f, 15.390f, 18.094f, 18.632f, 19.160f, 19.698f, 21.867f, 29.371f, 30.430f, 32.554f, 35.683f, 36.848f, 40.091f, 40.556f, 41.100f, 44.263f, 44.821f, 45.331f };
    private int nextBeatIndex = 0;

    void Start()
    {
        song.Play();
    }

    void Update()
    {
        if (nextBeatIndex < beatTimes.Length)
        {
            float currentSongTime = song.time;
            float nextBeatTime = beatTimes[nextBeatIndex];

            if (currentSongTime >= nextBeatTime - leadInTime)
            {
                SpawnNoteAt(nextBeatTime);
                nextBeatIndex++;
            }
            else if (currentSongTime > nextBeatTime)
            {
                Debug.LogWarning($"Missed beat {nextBeatIndex} at time {nextBeatTime}");
                nextBeatIndex++;
            }
        }
    }

    private void SpawnNoteAt(float beatTime)
    {
        Vector3 spawnPosition = new Vector3(spawnX, 0f, 0f);
        GameObject newNote = Instantiate(notePrefab, spawnPosition, Quaternion.identity);

        NoteController noteController = newNote.GetComponent<NoteController>();
        noteController.targetTime = beatTime;
        noteController.moveSpeed = moveSpeed;
    }
}
