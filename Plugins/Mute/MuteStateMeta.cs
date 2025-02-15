﻿using System.Text.Json.Serialization;

namespace IW4MAdmin.Plugins.Mute;

public class MuteStateMeta
{
    public string? Reason { get; set; }
    public DateTime? Expiration { get; set; }
    public MuteState MuteState { get; set; }
    [JsonIgnore] public bool CommandExecuted { get; set; }
}

public enum MuteState
{
    Muted,
    Unmuting,
    Unmuted
}
