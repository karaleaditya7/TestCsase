using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InflueriAutomation.Enums
{
    public enum AppDataShared
    {
        //Campaign 
        [Description("SEK")]
        CurrencySek,

        [Description("Sports")]
        Industry,

        [Description("Online traffic")]
        PurposeSection,

        [Description("Service Promotion")]
        Format,

        [Description("Norway")]
        country,

        [Description("Feed Photo")]
        FeedPhotoPost,

        [Description("Feed Video")]
        FeedVideoPost,

        [Description("Story Photo")]
        StoryPhotoPost,

        [Description("Story Video")]
        StoryVideoPost,

        [Description("Reels")]
        Reels,

        [Description("TikTok Video")]
        TikTokVideo,

        [Description("TikTok Story")]
        TikTokStory,

        [Description("Instagram")]
        GetOptionInstagram,

        [Description("TikTok")]
        GetOptionTikTok,

        [Description("alexandrapizzoni")]
        Alexandrapizzoni,

        [Description("anjaforsnor")]
        anjaforsnor,

        [Description("forlossningspodden")]
        forlossningspodden
    }
}
