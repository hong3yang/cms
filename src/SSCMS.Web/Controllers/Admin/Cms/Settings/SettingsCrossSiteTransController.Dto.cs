﻿using SSCMS.Dto.Request;

namespace SSCMS.Web.Controllers.Admin.Cms.Settings
{
    public partial class SettingsCrossSiteTransController
    {
        public class SubmitRequest : SiteRequest
        {
            public bool IsCrossSiteTransChecked { get; set; }
        }
    }
}