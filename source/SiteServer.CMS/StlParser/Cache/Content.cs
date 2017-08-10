using System;
using System.Collections.Generic;
using System.Globalization;
using BaiRong.Core;
using BaiRong.Core.Model;
using BaiRong.Core.Model.Enumerations;
using SiteServer.CMS.Core;

namespace SiteServer.CMS.StlParser.Cache
{
    public class Content
    {
        public static List<int> GetContentIdListChecked(string tableName, int nodeId, string orderByFormatString, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Content), nameof(GetContentIdListChecked), tableName, nodeId.ToString(), orderByFormatString);
            var retval = StlCacheUtils.GetCache<List<int>>(cacheKey);
            if (retval != null) return retval;

            retval = DataProvider.ContentDao.GetContentIdListChecked(tableName, nodeId, orderByFormatString);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }

        public static ContentInfo GetContentInfo(ETableStyle tableStyle, string tableName, int contentId, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Content), nameof(GetContentInfo), ETableStyleUtils.GetValue(tableStyle), tableName, contentId.ToString());
            var retval = StlCacheUtils.GetCache<ContentInfo>(cacheKey);
            if (retval != null) return retval;

            retval = DataProvider.ContentDao.GetContentInfo(tableStyle, tableName, contentId);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }

        public static ContentInfo GetContentInfo(int publishmentSystemId, int channelId, int contentId, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Content), nameof(GetContentInfo), publishmentSystemId.ToString(), channelId.ToString(), contentId.ToString());
            var retval = StlCacheUtils.GetCache<ContentInfo>(cacheKey);
            if (retval != null) return retval;

            retval = DataProvider.ContentDao.GetContentInfo(publishmentSystemId, channelId, contentId);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }

        public static string GetValue(string tableName, int contentId, string type, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Content), nameof(GetValue), tableName, contentId.ToString(), type);
            var retval = StlCacheUtils.GetCache<string>(cacheKey);
            if (retval != null) return retval;

            retval = BaiRongDataProvider.ContentDao.GetValue(tableName, contentId, type);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }

        public static int GetCountCheckedImage(int publishmentSystemId, int nodeId, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Content), nameof(GetCountCheckedImage), publishmentSystemId.ToString(), nodeId.ToString());
            var retval = StlCacheUtils.GetIntCache(cacheKey);
            if (retval != -1) return retval;

            retval = DataProvider.BackgroundContentDao.GetCountCheckedImage(publishmentSystemId, nodeId);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }

        public static int GetCountOfContentAdd(string tableName, int publishmentSystemId, int nodeId, EScopeType scope, DateTime begin, DateTime end, string userName, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Content), nameof(GetCountOfContentAdd), publishmentSystemId.ToString(), nodeId.ToString(), EScopeTypeUtils.GetValue(scope), begin.ToString(CultureInfo.InvariantCulture), end.ToString(CultureInfo.InvariantCulture), userName);
            var retval = StlCacheUtils.GetIntCache(cacheKey);
            if (retval != -1) return retval;

            retval = DataProvider.ContentDao.GetCountOfContentAdd(tableName, publishmentSystemId, nodeId, scope, begin, end, userName);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }

        public static DateTime GetAddDate(string tableName, int contentId, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Content), nameof(GetAddDate), tableName, contentId.ToString());
            var retval = StlCacheUtils.GetDateTimeCache(cacheKey);
            if (retval != DateTime.MinValue) return retval;

            retval = BaiRongDataProvider.ContentDao.GetAddDate(tableName, contentId);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }

        public static DateTime GetLastEditDate(string tableName, int contentId, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Content), nameof(GetLastEditDate), tableName, contentId.ToString());
            var retval = StlCacheUtils.GetDateTimeCache(cacheKey);
            if (retval != DateTime.MinValue) return retval;

            retval = BaiRongDataProvider.ContentDao.GetLastEditDate(tableName, contentId);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }

        public static int GetContentId(string tableName, int nodeId, int taxis, bool isNextContent, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Content), nameof(GetContentId), tableName, nodeId.ToString(), taxis.ToString(), isNextContent.ToString());
            var retval = StlCacheUtils.GetIntCache(cacheKey);
            if (retval != -1) return retval;

            retval = BaiRongDataProvider.ContentDao.GetContentId(tableName, nodeId, taxis, isNextContent);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }

        public static int GetContentId(string tableName, int nodeId, string orderByString, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Content), nameof(GetContentId), tableName, nodeId.ToString(), orderByString);
            var retval = StlCacheUtils.GetIntCache(cacheKey);
            if (retval != -1) return retval;

            retval = BaiRongDataProvider.ContentDao.GetContentId(tableName, nodeId, orderByString);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }        

        public static int GetNodeId(string tableName, int contentId, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Content), nameof(GetNodeId), tableName, contentId.ToString());
            var retval = StlCacheUtils.GetIntCache(cacheKey);
            if (retval != -1) return retval;

            retval = BaiRongDataProvider.ContentDao.GetNodeId(tableName, contentId);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }

        public static string GetStlWhereString(int publishmentSystemId, string tableName, string group, string groupNot, string tags, bool isImageExists, bool isImage, bool isVideoExists, bool isVideo, bool isFileExists, bool isFile, bool isTopExists, bool isTop, bool isRecommendExists, bool isRecommend, bool isHotExists, bool isHot, bool isColorExists, bool isColor, string where, bool isCreateSearchDuplicate, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Content), nameof(GetStlWhereString),
                publishmentSystemId.ToString(), tableName, group, groupNot,
                tags, isImageExists.ToString(), isImage.ToString(), isVideoExists.ToString(), isVideo.ToString(),
                isFileExists.ToString(), isFile.ToString(), isTopExists.ToString(), isTop.ToString(),
                isRecommendExists.ToString(), isRecommend.ToString(), isHotExists.ToString(), isHot.ToString(),
                isColorExists.ToString(), isColor.ToString(), where,
                isCreateSearchDuplicate.ToString());
            var retval = StlCacheUtils.GetCache<string>(cacheKey);
            if (retval != null) return retval;

            retval = DataProvider.BackgroundContentDao.GetStlWhereString(publishmentSystemId, tableName, group, groupNot,
                tags, isImageExists, isImage, isVideoExists, isVideo, isFileExists, isFile, isTopExists, isTop,
                isRecommendExists, isRecommend, isHotExists, isHot, isColorExists, isColor, where,
                isCreateSearchDuplicate);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }

        public static string GetStlWhereString(int publishmentSystemId, string group, string groupNot, string tags, bool isTopExists, bool isTop, string where, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Content), nameof(GetStlWhereString),
                publishmentSystemId.ToString(), group, groupNot, tags, isTopExists.ToString(), isTop.ToString(), where);
            var retval = StlCacheUtils.GetCache<string>(cacheKey);
            if (retval != null) return retval;

            retval = BaiRongDataProvider.ContentDao.GetStlWhereString(publishmentSystemId, group, groupNot, tags, isTopExists, isTop, where);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }

        public static string GetStlSqlStringChecked(string tableName, int publishmentSystemId, int nodeId, int startNum, int totalNum, string orderByString, string whereString, EScopeType scopeType, string groupChannel, string groupChannelNot, bool isNoDup, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Content), nameof(GetStlSqlStringChecked),
                tableName, publishmentSystemId.ToString(), nodeId.ToString(), startNum.ToString(), totalNum.ToString(), orderByString, whereString, EScopeTypeUtils.GetValue(scopeType), groupChannel, groupChannelNot, isNoDup.ToString());
            var retval = StlCacheUtils.GetCache<string>(cacheKey);
            if (retval != null) return retval;

            retval = DataProvider.ContentDao.GetStlSqlStringChecked(tableName, publishmentSystemId, nodeId, startNum, totalNum, orderByString, whereString, scopeType, groupChannel, groupChannelNot, isNoDup);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }

        public static string GetStlWhereStringBySearch(string tableName, string group, string groupNot, string tags, bool isImageExists, bool isImage, bool isVideoExists, bool isVideo, bool isFileExists, bool isFile, bool isTopExists, bool isTop, bool isRecommendExists, bool isRecommend, bool isHotExists, bool isHot, bool isColorExists, bool isColor, string where, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Content), nameof(GetStlWhereStringBySearch), tableName, group, groupNot, tags, isImageExists.ToString(), isImage.ToString(), isVideoExists.ToString(), isVideo.ToString(), isFileExists.ToString(), isFile.ToString(), isTopExists.ToString(), isTop.ToString(), isRecommendExists.ToString(), isRecommend.ToString(), isHotExists.ToString(), isHot.ToString(), isColorExists.ToString(), isColor.ToString(), where);
            var retval = StlCacheUtils.GetCache<string>(cacheKey);
            if (retval != null) return retval;

            retval = DataProvider.BackgroundContentDao.GetStlWhereStringBySearch(tableName, group, groupNot, tags, isImageExists, isImage, isVideoExists, isVideo, isFileExists, isFile, isTopExists, isTop, isRecommendExists, isRecommend, isHotExists, isHot, isColorExists, isColor, where);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }

        public static string GetStlSqlStringCheckedBySearch(string tableName, int startNum, int totalNum, string orderByString, string whereString, bool isNoDup, string guid)
        {
            var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(Content), nameof(GetStlSqlStringCheckedBySearch),
                tableName, startNum.ToString(), totalNum.ToString(), orderByString, whereString, isNoDup.ToString());
            var retval = StlCacheUtils.GetCache<string>(cacheKey);
            if (retval != null) return retval;

            retval = DataProvider.ContentDao.GetStlSqlStringCheckedBySearch(tableName, startNum, totalNum, orderByString, whereString, isNoDup);
            StlCacheUtils.SetCache(cacheKey, retval);
            return retval;
        }
    }
}
