
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SetActiveInHierarchyArray : UdonSharpBehaviour
{
    public GameObject[] vocabTerms;
    [UdonSynced] public bool vocabVisible = false;

    void Start()
    {
        foreach (GameObject term in vocabTerms)
        {
            term.SetActive(false);
        }
    }
    public override void Interact()
    {
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        vocabVisible = !vocabVisible;
        VocabVisibilitySwitch();
        RequestSerialization();
    }
    public void VocabVisibilitySwitch()
    {
        foreach (GameObject term in vocabTerms)
        {
            term.SetActive(vocabVisible);
        }
    }
    public override void OnDeserialization()
    {
        VocabVisibilitySwitch();
    }
}
