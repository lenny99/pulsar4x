﻿using Helion4x.Core.Settlement.Installation;

namespace Helion4x.Core.Settlement.Sectors
{
    public class TertiarySector : Sector
    {
        public override float CalculateJobs(InstallationBonuses bonuses)
        {
            _jobs = bonuses.Get(InstallationBonus.TertiarySectorJobs);
            return _jobs;
        }
    }
}