﻿using System.Threading.Tasks;

namespace SSCMS
{
    public partial interface IChannelRepository
    {
        Task UpdateTaxisDownAsync(int siteId, int channelId, int parentId, int taxis);

        Task UpdateTaxisUpAsync(int siteId, int channelId, int parentId, int taxis);
    }
}
