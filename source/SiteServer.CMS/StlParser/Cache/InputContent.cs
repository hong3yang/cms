using BaiRong.Core;
using BaiRong.Core.Model;
using SiteServer.CMS.Core;
using SiteServer.CMS.Model;

namespace SiteServer.CMS.StlParser.Cache
{
    public class InputContent
    {
        public static InputContentInfo GetContentInfo(int id, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(InputContent), nameof(GetContentInfo), id.ToString());
            var retval = StlCacheUtils.GetCache<InputContentInfo>(cacheKey);
            if (retval != null) return retval;

            retval = DataProvider.InputContentDao.GetContentInfo(id);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }

        public static string GetSelectSqlStringWithChecked(int publishmentSystemId, int inputId, bool isReplyExists, bool isReply, int startNum, int totalNum, string whereString, string orderByString, LowerNameValueCollection others, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(InputContent), nameof(GetSelectSqlStringWithChecked), publishmentSystemId.ToString(), inputId.ToString(), isReplyExists.ToString(), isReply.ToString(), startNum.ToString(), totalNum.ToString(), whereString, orderByString, TranslateUtils.NameValueCollectionToString(others));
            var retval = StlCacheUtils.GetCache<string>(cacheKey);
            if (retval != null) return retval;

            retval = DataProvider.InputContentDao.GetSelectSqlStringWithChecked(publishmentSystemId, inputId, isReplyExists, isReply, startNum, totalNum, whereString, orderByString, others);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }

        
    }
}
