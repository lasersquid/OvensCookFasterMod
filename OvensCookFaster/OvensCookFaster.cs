using HarmonyLib;


#if MONO_BUILD
using ScheduleOne.ObjectScripts;
using ScheduleOne.StationFramework;
#else
using Il2CppScheduleOne.ObjectScripts;
using Il2CppScheduleOne.StationFramework;
#endif

namespace OvensCookFaster
{
    [HarmonyPatch(typeof(OvenCookOperation), "GetCookDuration")]
    public static class OvenCookOperationGetCookDurationPatch
    {
        private static int _divider = 4;

        // For passing state between prefix and postfix.
        public class GetCookDurationState(OvenCookOperation operation)
        {
            public OvenCookOperation operation = operation;
            public int oldCookDuration = (int)Traverse.Create(operation).Field("cookDuration").GetValue();
        }

        [HarmonyPrefix]
        public static void Prefix(OvenCookOperation __instance, out GetCookDurationState __state)
        {
            __state = new GetCookDurationState(__instance);
        }

        [HarmonyPostfix]
        public static void Postfix(ref int __result, GetCookDurationState __state)
        {
            if (__state.oldCookDuration == -1)
            {
                Traverse.Create(__state.operation).Field("cookDuration").SetValue(__state.oldCookDuration / _divider);
            }
            __result = __state.oldCookDuration / _divider;
        }
    }
}
