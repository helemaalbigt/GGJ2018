using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.UnityEventHelper;

public class UnlockStep : GameStep {
    public VRTK_SnapDropZone_UnityEvents events;

    public override void StartStep() {
        events.OnObjectSnappedToDropZone.AddListener(OnUnlock);

        Invoke("Next", 2f);
    }

    private void OnUnlock(object arg0, SnapDropZoneEventArgs snapDropZoneEventArgs) {
        Next();
    }
}
