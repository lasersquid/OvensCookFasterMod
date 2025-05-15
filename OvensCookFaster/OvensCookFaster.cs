using HarmonyLib;

#if MONO_BUILD
using ScheduleOne.ObjectScripts;
#else
using Il2CppScheduleOne.ObjectScripts;
#endif

namespace OvensCookFaster
{
    [HarmonyPatch(typeof(OvenCookOperation), "GetCookDuration")]
    public static class OvenCookOperationGetCookDurationPatch
    {
        private static int _divider = 4;

        [HarmonyPostfix]
        public static void Postfix(ref int __result)
        {
            __result = __result / _divider;
        }
    }

    // I have a suspicion GetCookDuration may be inlined in some places.
    // Without this patch chemists stand idle at labovens for several minutes. 
    [HarmonyPatch(typeof(OvenCookOperation), "IsReady")]
    public static class OvenCookOperationIsReadyPatch
    {
        [HarmonyPostfix]
        public static void Postfix(OvenCookOperation __instance, ref bool __result)
        {
            // Re-insert original method body.
            __result = __instance.CookProgress >= __instance.GetCookDuration();
        }
    }
}
