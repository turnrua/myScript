using System;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;
using Newtonsoft.Json;
using Dalamud.Utility.Numerics;
using KodakkuAssist.Script;
using KodakkuAssist.Module.GameEvent;
using KodakkuAssist.Module.Draw;

namespace PVP不被dk吸;

[ScriptType(guid: "FEEE5335-2354-671D-80CC-C911CD5C55DC", name: "PVPdk吸防御", territorys: [], version: "0.0.0.1", author: "chris")]
public class dk吸防御Class
{
    [UserSetting("频道")] public string channel { get; set; } = "e";
    [UserSetting("提示音")] public string se { get; set; } = "<se.1><se.1>";
    [ScriptMethod(name: "dk吸防御", eventType: EventTypeEnum.ActionEffect, eventCondition: ["ActionId:29094"])]
  public   void 不被dk吸(Event @event, ScriptAccessory accessory)
    {
        if (@event.TargetId() != accessory.Data.Me) return;
	      accessory.Method.SendChat($"/pvpac  防御");
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
