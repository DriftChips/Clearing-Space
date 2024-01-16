using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationInventory : MonoBehaviour
{
    //
    /*public List<Refinery> refineries;

    public int junkCounter;

    private void Update()
    {
        bool isAnyRefineryRefining = false;

        // Check if any refinery is refining
        foreach (Refinery refinery in refineries)
        {
            if (refinery.isRefining)
            {
                isAnyRefineryRefining = true;
                break;
            }
        }

        if (!isAnyRefineryRefining)
        {
            // No refinery is currently refining, so send junk to the first refinery
            SendJunkToRefinery(refineries[0]);
        }
        else
        {
            // At least one refinery is refining, so check the next refinery
            for (int i = 0; i < refineries.Count; i++)
            {
                Refinery refinery = refineries[i];
                if (!refinery.isRefining)
                {
                    // This refinery is not refining, so send junk to it
                    SendJunkToRefinery(refinery);
                    break;
                }
                else if (i == refineries.Count - 1)
                {
                    // All refineries are currently refining, so start over with the first refinery
                    i = -1;
                }
            }
        }
    }

    private void SendJunkToRefinery(Refinery refinery)
    {
        // TODO: Send junk to the specified refinery
    }*/
}