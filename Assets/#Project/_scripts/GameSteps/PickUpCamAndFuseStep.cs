using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.UnityEventHelper;

public class PickUpCamAndFuseStep : GameStep {
    [Space(15)]
    public TextPrompt _prompt;

    public VRTK_InteractableObject_UnityEvents cam;
    public VRTK_SnapDropZone_UnityEvents fuse1;
    public VRTK_SnapDropZone_UnityEvents fuse2;
    public VRTK_SnapDropZone_UnityEvents fuse3;
    public KillerCollider ceilingCollider;
    public PushAction pushAction;
    public PushAction dropPanel;
    public GameStep failStep;

    [Space(15)]
    public bool autoGrabCam;
    public bool autoGrabFuses;

    private string msg1 = "\"Now tell them to pick up that handheld camera so we can see the inside.\"";
    private string msg2 = "\"There should be three fuses...\"";
    private string msg3 = "\"... and if they disconnect them in the right order, it should open the door.\"";
    private string msg4 = "\"Tell them to pull the top, then the bottom and finally the middle one.\"";

    private string msg5 = "\"WHAT DID YOU DO?!\"";
    private string msg6 = "\"IS THAT CEILING COMING DOWN?!!\"";
    private string msg7 = "\"QUICK! TELL THEM TO GRAB THAT CAMERA!\"";
    private string msg8 = "\"YOU BETTER MAKE SURE THEY GET OUT OF THIS ALIVE!\"";

    private int fusesPulled = 0;
    private bool allFusesPulled;
    private bool camPickedUp;
    private bool playerDied;

    public override void StartStep() {
        cam.OnGrab.AddListener(OnGrabCam);
        fuse1.OnObjectUnsnappedFromDropZone.AddListener(OnGrabFuse);
        fuse2.OnObjectUnsnappedFromDropZone.AddListener(OnGrabFuse);
        fuse3.OnObjectUnsnappedFromDropZone.AddListener(OnGrabFuse);
        ceilingCollider.collisionEvents.AddListener(OnCeilingKill);
        pushAction.PushCompletedEvents.AddListener(OnPlayerSurvive);

        ShowMsg1();

        StartCoroutine(WaitForNextState());

        if (autoGrabCam) {
            camPickedUp = true;
            Invoke("ShowMsg2", 6f);
        }
        if (autoGrabFuses) {
            Invoke("SetAllFusesPulled",20f);
        }
    }

    private void ShowMsg1() {
        _prompt.ShowText(msg1);
    }

    private void ShowMsg2() {
        _prompt.Clear();
        _prompt.ShowText(msg2, ShowMsg3);
    }

    private void ShowMsg3() {
        _prompt.ShowText(msg3, ShowMsg4);
    }

    private void ShowMsg4() {
        _prompt.ShowText(msg4);
    }

    private void ShowMsg5() {
        _prompt.Clear();
        _prompt.ShowText(msg5, ShowMsg6);
    }

    private void ShowMsg6() {
        if (camPickedUp) {
            _prompt.ShowText(msg6, ShowMsg8);
        } else {
            _prompt.ShowText(msg6, ShowMsg7);
        }
    }

    private void ShowMsg7() {
        _prompt.ShowText(msg7, ShowMsg8);
    }

    private void ShowMsg8() {
        _prompt.ShowText(msg8, 5f);
    }

    private void OnGrabCam(object arg0, InteractableObjectEventArgs interactableObjectEventArgs) {
        camPickedUp = true;
        if (!allFusesPulled) {
            ShowMsg2();
        }
    }

    private void OnGrabFuse(object arg0, SnapDropZoneEventArgs snapDropZoneEventArgs) {
        fusesPulled++;
    }

    IEnumerator WaitForNextState() {
        while (fusesPulled < 3) {
            yield return null;
        }

        allFusesPulled = true;
        pushAction.Push();
        dropPanel.Push();

        ShowMsg5();
    }

    private void SetAllFusesPulled() {
        fusesPulled = 3;
    }

    private void OnCeilingKill() {
        if (!playerDied) {
            playerDied = true;
            failStep.StartStep();
        }
    }

    private void OnPlayerSurvive() {
        _prompt.Clear();
        Next();
    }
}
