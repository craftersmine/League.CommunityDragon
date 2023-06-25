﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.League.CommunityDragon
{
    public interface IAsset
    {
        Task<Stream> GetAssetStreamAsync();

        internal string GetAssetUri();
    }
}