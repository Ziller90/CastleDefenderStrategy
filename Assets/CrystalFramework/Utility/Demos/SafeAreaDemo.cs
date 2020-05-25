using UnityEngine;
using System;

namespace Crystal
{
    public class SafeAreaDemo : MonoBehaviour
    {
        [SerializeField] KeyCode KeySafeArea = KeyCode.M;
        SafeArea.SimDevice[] Sims;
        int SimIdx;

        void Awake ()
        {
            if (!Application.isEditor)
                Destroy (this);

            Sims = (SafeArea.SimDevice[])Enum.GetValues (typeof (SafeArea.SimDevice));
        }

        void Update ()
        {
            if (Input.GetKeyDown (KeyCode.M))
                ToggleSafeArea ();
        }

        /// <summary>
        /// Toggle the safe area simulation device.
        /// </summary>
        void ToggleSafeArea ()
        {
            SimIdx++;

            if (SimIdx >= Sims.Length)
                SimIdx = 0;

            SafeArea.Sim = Sims[SimIdx];
            Debug.LogFormat ("Switched to sim device {0} with debug key '{1}'", Sims[SimIdx], KeySafeArea);
        }
    }
}
