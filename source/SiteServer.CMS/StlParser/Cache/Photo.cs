using System.Collections.Generic;
using SiteServer.CMS.Core;
using SiteServer.CMS.Model;

namespace SiteServer.CMS.StlParser.Cache
{
    public class Photo
    {
        public static List<PhotoInfo> GetPhotoInfoList(int publishmentSystemId, int contentId, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Photo), nameof(GetPhotoInfoList), publishmentSystemId.ToString(), contentId.ToString());
            var retval = StlCacheUtils.GetCache<List<PhotoInfo>>(cacheKey);
            if (retval != null) return retval;

            retval = DataProvider.PhotoDao.GetPhotoInfoList(publishmentSystemId, contentId);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }

        public static PhotoInfo GetFirstPhotoInfo(int publishmentSystemId, int contentId, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Photo), nameof(GetFirstPhotoInfo), publishmentSystemId.ToString(), contentId.ToString());
            var retval = StlCacheUtils.GetCache<PhotoInfo>(cacheKey);
            if (retval != null) return retval;

            retval = DataProvider.PhotoDao.GetFirstPhotoInfo(publishmentSystemId, contentId);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }
    }
}
