// Guids.cs
// MUST match guids.h
using System;

namespace Mosaic.SwitchSettings
{
    static class GuidList
    {
        public const string guidSwitchSettingsPkgString = "e06bbdd3-e1e8-4ff8-9de0-7979848ec125";
        public const string guidSwitchSettingsCmdSetString = "78709233-8fde-4ade-a9d7-725b56730f34";

        public static readonly Guid guidSwitchSettingsCmdSet = new Guid(guidSwitchSettingsCmdSetString);
    };
}