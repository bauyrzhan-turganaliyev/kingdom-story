using System;
using System.Collections.Generic;
using oks.Core;
using oks.GameResources;
using UnityEngine;

namespace oks.Shop
{
    public class TraderInfo : MonoBehaviour
    {
        [SerializeField] private List<Resource> _resourceList;

        public void Init(List<Resource> resourceList)
        {
            _resourceList = resourceList;
        }
    }
}