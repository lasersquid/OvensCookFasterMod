using Il2CppScheduleOne.ObjectScripts;
using HarmonyLib;

namespace OvensCookFaster
{
    [HarmonyPatch(typeof(OvenCookOperation), "GetCookDuration")]
    public static class OvenCookOperationGetCookDurationPatch
    {
        private static int _divider = 4;

        [HarmonyPostfix]
        public static int Postfix(OvenCookOperation __instance, ref int __result)
        {
            return __result / _divider;
        }
    }

    /*
    [HarmonyPatch(typeof(OvenCookOperation), MethodType.Constructor)]
    public static class OvenCookOperationCtorPatch
    {
        private static int _divider = 4;

        [HarmonyPostfix]
        public static OvenCookOperation Postfix(ref OvenCookOperation __result)
        {
            __result.cookDuration = __result.cookDuration / _divider;

            return __result;
        }
    }
    */
}
