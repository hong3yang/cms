﻿using SSCMS;

namespace SSCMS.Web.Controllers.Admin.Settings.Administrators
{
    public partial class AdministratorsAccessTokensViewLayerController
    {
        public class GetResult
        {
            public AccessToken Token { get; set; }
            public string AccessToken { get; set; }
        }

        public class RegenerateResult
        {
            public string AccessToken { get; set; }
        }
    }
}
