using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Proje ilk acildiginda oyun sahnesini otomatik yukler.
/// Git'ten indirilen projelerde bos hiyerarsi sorununu onler.
/// </summary>
[InitializeOnLoad]
public static class SayiTahminProjeAcilisi
{
    private const string OyunSahneYolu = "Assets/Scenes/SampleScene.unity";

    static SayiTahminProjeAcilisi()
    {
        EditorApplication.delayCall += OyunSahnesiniAc;
    }

    private static void OyunSahnesiniAc()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode)
        {
            return;
        }

        Scene aktifSahne = SceneManager.GetActiveScene();
        if (!string.IsNullOrEmpty(aktifSahne.path))
        {
            return;
        }

        if (!System.IO.File.Exists(OyunSahneYolu))
        {
            Debug.LogWarning($"Oyun sahnesi bulunamadi: {OyunSahneYolu}");
            return;
        }

        EditorSceneManager.OpenScene(OyunSahneYolu);
    }
}
