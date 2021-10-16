namespace AspireSystems.TakeYourJob.WebApi.IntegrationTest.Core.Helper
{
    /// <summary>
    /// Stores all the constants that shall be used by any Test
    /// </summary>
    public static class Constants
    {
        //Authentication Api
        public const string authenticationUri = "/api/authenticate/login";

        //District Api
        public const string districtUri = "/api/District";

        //SOPAssessment Api
        public const string sopAssessmentUri = "/api/sopassessment";
        public const string sopDeleteAssessmentUri = "/api/sopassessment/{0}";
        public const string submitSopAssessmentUri = "/api/sopassessment/submit";
        public const string getByGroupSopAssessmentUri = "/api/sopassessment/getbygroup/{0}";
        public const string saveSopAssessmentUri = "/api/sopassessment/save";
        public const string saveCoachingToolSopAssessmentUri = "/api/sopassessment/savecoachingtool";

        //SOPAssessment Group Api
        public const string sopAssessmentGroupUri = "/api/sopassessmentgroup";
        public const string getByStoreSopAssessmentGroupUri = "/api/sopassessmentgroup/getbystore/{sopAssessmentGroupId}";

        //FleetDetail Api
        public const string fleetDetailUri = "/api/fleet/savefleetdetail";
        public const string fleetUri = "/api/fleet";

        //SopAssessmentTemplate Api
        public const string sopAssessmentTemplateUri = "/api/SOPAssessmentTemplate/GetTemplatebyFormType/{0},{1}";
    }
}
