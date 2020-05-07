using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveCounter : MonoBehaviour
{
    MapSetting mapSetting;
    CripsSpawner MainSpawner;
    public Text WaveCounterText;
    public Text WaveCounterTextShad;

    public bool AlreadyStart;

    void Start()
    {
        mapSetting = LinksContainer.instance.Level.GetComponent<MapSetting>();
        MainSpawner = mapSetting.MainSpawner;
        StartCoroutine("BattleBeforeFight");
    }

    // Update is called once per frame
    void Update()
    {
        WaveCounterTextShad.text = WaveCounterText.text;
        if (AlreadyStart == true)
        {
            float NumberOfWave = MainSpawner.SquadCounter;
            NumberOfWave = Mathf.Clamp(NumberOfWave, 1, 100f);
            WaveCounterText.text = NumberOfWave + "/" + MainSpawner.AmountOFCrips.Length;
            WaveCounterTextShad.text = NumberOfWave + "/" + MainSpawner.AmountOFCrips.Length; ;
}
    }
    IEnumerator BattleBeforeFight ()
    {
        if (MainSpawner.SquadTime[0] >= 10)
        {
            WaveCounterText.text = "00:" + MainSpawner.SquadTime[0];
            WaveCounterTextShad.text = "00:" + MainSpawner.SquadTime[0];
        }
        else
        {
            WaveCounterText.text = "00:0" + MainSpawner.SquadTime[0];
            WaveCounterTextShad.text = "00:0" + MainSpawner.SquadTime[0];
        }
        for (int i = MainSpawner.SquadTime[0]; i > -1; i-- )
        {
            yield return new WaitForSeconds(1);
            if (i >= 10)
            {
                WaveCounterText.text = "00:" + i;
                WaveCounterTextShad.text = "00:" + i;
            }
            else
            {
                WaveCounterText.text = "00:0" + i;
                WaveCounterTextShad.text = "00:0" + i;
            }

        }
        yield return new WaitForSeconds(1);
        AlreadyStart = true;
    }
}
