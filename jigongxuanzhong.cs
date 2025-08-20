using System;
using System.Linq;
using System.Numerics;
using Newtonsoft.Json;
using Dalamud.Utility.Numerics;
using KodakkuAssist.Script;
using KodakkuAssist.Module.GameEvent;
using KodakkuAssist.Module.Draw;

namespace PVP机工LB提示;

[ScriptType(guid: "C0C67BDA-B6B3-411D-8C7F-C3161335BEB3", name: "PVP机工LB提示", territorys: [], version: "0.0.0.2", author: "chris")]
public class 机工LBClass
{
    [ScriptMethod(name: "LB提示", eventType: EventTypeEnum.ActionEffect, eventCondition: ["ActionId:29415"])]
    public void 机工LB(Event @event, ScriptAccessory accessory)
    {
        if (@event.TargetId() != accessory.Data.Me) return;

        accessory.Method.TextInfo("机工LB!", 2000);
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
}
