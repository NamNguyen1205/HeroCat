using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "RPG Setup/Audio/AudioDataBase", fileName = "Audio_Database")]
public class AudioDataBaseSO : ScriptableObject
{
    public List<AudioClipData> attackSound;
    public List<AudioClipData> player;
    public Dictionary<string, AudioClipData> audioCollection;

    private void OnEnable()
    {
        if (audioCollection == null)
            audioCollection = new Dictionary<string, AudioClipData>();

        AddAudioClipDataToCollection(attackSound);
        AddAudioClipDataToCollection(player);
    }

    public AudioClipData GetAudioByName(string audioName) => audioCollection.TryGetValue(audioName, out AudioClipData audioClip) ? audioClip : null;
    
    private void AddAudioClipDataToCollection(List<AudioClipData> listToAdd)
    {
        if (listToAdd == null) return;
        foreach(var data in listToAdd)
        {
            if (audioCollection.ContainsKey(data.audioName))
                continue;

            audioCollection.Add(data.audioName, data);
        }
    }
}

[Serializable]
public class AudioClipData
{
    public string audioName;
    public List<AudioClip> audioList;

    public AudioClip GetRandomAudio() => audioList[UnityEngine.Random.Range(0, audioList.Count)];
    
}