using System;
using System.Collections.Generic;
using System.Text;

namespace DBDStatBot.Models
{
    ///< summary >
    /// Enum that's used to filter out unwanted or ununcessary stat categories from the Steam API.
    /// </ summary >
    public enum StatFilterEnum
    {
        DBD_SkillCheckSuccess,
        DBD_Escape,
        DBD_BloodwebPoints,
        DBD_EscapeThroughHatch,
        DBD_HitNearHook
    }
}
