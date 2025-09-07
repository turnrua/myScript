using System;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;
using Newtonsoft.Json;
using Dalamud.Utility.Numerics;
using KodakkuAssist.Script;
using KodakkuAssist.Module.GameEvent;
using KodakkuAssist.Module.Draw;

namespace PVP战士死斗提示;

[ScriptType(guid: "5EB4C3B1-7310-4964-B269-6569AE4F43D7", name: "PVP战士死斗提示", territorys: [], version: "0.0.0.4", author: "chris")]
public class 战士死斗Class
{
    [UserSetting("频道")] public string channel { get; set; } = "e";
    [UserSetting("提示音")] public string se { get; set; } = "<se.1><se.1>";
    [ScriptMethod(name: "战士死斗提示", eventType: EventTypeEnum.ActionEffect, eventCondition: ["ActionId:29081"])]
    public void 机工LB(Event @event, ScriptAccessory accessory)
    {
        if (@event.TargetId() != accessory.Data.Me) return;

        accessory.Method.TextInfo("死斗!", 2000);
		 await Task.Delay(300);
	accessory.Method.SendChat($"/pvpac  净化");
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





