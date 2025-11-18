using System;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using Newtonsoft.Json;
using Dalamud.Utility.Numerics;
using KodakkuAssist.Script;
using KodakkuAssist.Module.GameEvent;
using KodakkuAssist.Module.Draw;
using KodakkuAssist.Data;
using KodakkuAssist.Extensions;
using System.Threading.Tasks;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.Game.Character;
using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.Control;
using FFXIVClientStructs.FFXIV.Client.Game.UI;

namespace PVP控制;

[ScriptType(guid: "C64FA0B3-719A-2D37-ED82-962DC02ADA51", name: "PVP控制", territorys: [250, 431, 554, 888, 1273], version: "0.0.0.2", author: "chris")]
public class 机工LBClass
{
    [UserSetting("TTS开关")]
    public bool isTTS { get; set; } = true;

    [UserSetting("EdgeTTS开关")]
    public bool isEdgeTTS { get; set; } = true;
    [ScriptMethod(name: "战场眩晕", eventType: EventTypeEnum.StatusAdd, eventCondition: ["StatusID:1343"])]
    public void 战场眩晕(Event @event, ScriptAccessory accessory)
    {
        if (@event.TargetId() != accessory.Data.Me) return;

        if (isTTS) accessory.Method.TTS("净化净化");
        if (isEdgeTTS) accessory.Method.EdgeTTS("净化净化");
    }
    [ScriptMethod(name: "战场沉默", eventType: EventTypeEnum.StatusAdd, eventCondition: ["StatusID:1347"])]
    public async void 战场沉默(Event @event, ScriptAccessory accessory)
    {
        if (@event.TargetId() != accessory.Data.Me) return;
        await Task.Delay(100);
        accessory.Method.SendChat($"/pvpac  净化");
        if (isTTS) accessory.Method.TTS("已净化");
        if (isEdgeTTS) accessory.Method.EdgeTTS("已净化");
    }
    [ScriptMethod(name: "战场止步", eventType: EventTypeEnum.StatusAdd, eventCondition: ["StatusID:1345"])]
    public void 战场止步(Event @event, ScriptAccessory accessory)
    {
        if (@event.TargetId() != accessory.Data.Me) return;

        if (isTTS) accessory.Method.TTS("净化净化");
        if (isEdgeTTS) accessory.Method.EdgeTTS("净化净化");
    }
    [ScriptMethod(name: "战场冻结", eventType: EventTypeEnum.StatusAdd, eventCondition: ["StatusID:xxxx"])]
    public void 战场冻结(Event @event, ScriptAccessory accessory)
    {
        if (@event.TargetId() != accessory.Data.Me) return;

        if (isTTS) accessory.Method.TTS("净化净化");
        if (isEdgeTTS) accessory.Method.EdgeTTS("净化净化");
    }
     [ScriptMethod(name: "战场变猪", eventType: EventTypeEnum.StatusAdd, eventCondition: ["StatusID:3085"])]
    public async void 战场变猪(Event @event, ScriptAccessory accessory)
    {
        if (@event.TargetId() != accessory.Data.Me) return;
        await Task.Delay(100);
        accessory.Method.SendChat($"/pvpac  净化");
        if (isTTS) accessory.Method.TTS("已净化");
        if (isEdgeTTS) accessory.Method.EdgeTTS("已净化");
    }
}


public static class EventExtensions
{
    private static bool ParseHexId(string? idStr, out uint id)
    {
        id = 0;
        if (string.IsNullOrEmpty(idStr)) return false;
        try
        {
            var idStr2 = idStr.Replace("0x", "");
            id = uint.Parse(idStr2, System.Globalization.NumberStyles.HexNumber);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static uint TargetId(this Event @event)
    {
        return ParseHexId(@event["TargetId"], out var id) ? id : 0;
    }
    public static uint SourceId(this Event @event)
    {
        return ParseHexId(@event["SourceId"], out var id) ? id : 0;
    }
    
    public static uint State(this Event @event)
    {
        return ParseHexId(@event["State"], out var state) ? state : 0;
    }
    public static Vector3 SourcePosition(this Event @event)
    {
        return JsonConvert.DeserializeObject<Vector3>(@event["SourcePosition"]);
    }
    public static Vector3 EffectPosition(this Event @event)
    {
        return JsonConvert.DeserializeObject<Vector3>(@event["EffectPosition"]);
    }
        public static uint StatusId(this Event @event)
    {
        return JsonConvert.DeserializeObject<uint>(@event["StatusId"]);
    }
}
