﻿namespace SSCMS.Web.Controllers.Admin
{
    public partial class SyncDatabaseController
    {
        public class GetResult
        {
            public string DatabaseVersion { get; set; }
            public string ProductVersion { get; set; }
        }

        public class SubmitResult
        {
            public string Version { get; set; }
        }
    }
}
