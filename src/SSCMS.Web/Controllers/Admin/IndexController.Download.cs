﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSCMS;
using SSCMS.Dto.Result;
using SSCMS.Core.Packaging;
using SSCMS.Utils;

namespace SSCMS.Web.Controllers.Admin
{
    public partial class IndexController
    {
        [HttpPost, Route(RouteActionsDownload)]
        public async Task<ActionResult<BoolResult>> Download([FromBody] DownloadRequest request)
        {
            
            if (!await _authManager.IsAdminAuthenticatedAsync())
            {
                return Unauthorized();
            }

            try
            {
                PackageUtils.DownloadPackage(_pathManager, request.PackageId, request.Version);
            }
            catch
            {
                PackageUtils.DownloadPackage(_pathManager, request.PackageId, request.Version);
            }

            var isDownload = PackageUtils.IsPackageDownload(_pathManager, request.PackageId, request.Version);
            if (isDownload)
            {
                if (StringUtils.EqualsIgnoreCase(request.PackageId, PackageUtils.PackageIdSsCms))
                {
                    await _dbCacheRepository.RemoveAndInsertAsync(PackageUtils.CacheKeySsCmsIsDownload, true.ToString());
                }
            }

            return new BoolResult
            {
                Value = isDownload
            };
        }
    }
}
