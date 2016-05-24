﻿using aveva.viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;

namespace aveva.itemtranslator
{
    public class MainPageItemBuilder : IItemBuilder<HeaderViewModel>
    {
        public HeaderViewModel CreateModel(Item sitecoreItem)
        {
            var headerItem = sitecoreItem.GetChildren().FirstOrDefault(x => x.TemplateName == "HeaderTemplate");
            var headerViewModel = new HeaderViewModel();
            headerViewModel.Title = headerItem.Fields["Title"].ToString();
            string url = String.Empty;
            ImageField imageField = headerItem.Fields["Logo"];
            if (imageField != null && imageField.MediaItem != null)
            {
                MediaItem media = new MediaItem(imageField.MediaItem);
                headerViewModel.LogoUrl = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(media));
            }

            return headerViewModel;
        }

        public Item TranslateToItem()
        {
            throw new NotImplementedException();
        }
    }
}
