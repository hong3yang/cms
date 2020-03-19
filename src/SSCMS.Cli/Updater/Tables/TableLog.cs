﻿using System;
using Newtonsoft.Json;
using SSCMS;

namespace SSCMS.Cli.Updater.Tables
{
    public partial class TableLog
    {
        private readonly IDatabaseManager _databaseManager;

        public TableLog(IDatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("ipAddress")]
        public string IpAddress { get; set; }

        [JsonProperty("addDate")]
        public DateTimeOffset AddDate { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }
    }
}
