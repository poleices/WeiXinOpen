using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
//using System.Runtime.Serialization;

namespace Open.WeiXin
{
    public class TokenResult
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }

    public enum MessageType
    {
        [Description("文本消息")]
        text = 0,

        [Description("语音消息")]
        voice = 1,
        [Description("图片消息")]
        image=2,

        [Description("视频消息")]
        video = 3,

        [Description("地理们置消息")]
        location = 4,

        [Description("链接消息")]
        link = 5,

        [Description("事件消息")]
        Event=6
    }

    public enum EventType
    { 
        subscribe=0,
        unsubscribe=1,
        SCAN=3,
        LOCATION=4,
        CLICK=5

    }

    public class RequestTextMessage
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public string CreateTime { get; set; }
        public string MsgType { get; set; }
        public string Content { get; set; }
        public string MsgId { get; set; }        
    }

    public class RequestMessage
    {
        //普通消息
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public string CreateTime { get; set; }
        public string MsgType { get; set; }
        public string Content { get; set; }
        public string MsgId { get; set; }

        //图片
        public string PicUrl { get; set; }
        public string MediaId { get; set; }

        //语音
        public string Format { get; set; }

        //视频
        public string ThumbMediaId { get; set; }

        //地理位置
        public string Location_X { get; set; }
        public string Location_Y { get; set; }
        public string Scale { get; set; }
        public string Label { get; set; }

        //链接
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        //事件消息
        //订阅，取消订阅事件
        public string Event { get; set; }

        //扫描二维码事件
        public string EventKey { get; set; } //事件KEY值，是一个32位无符号整数，即创建二维码时的二维码scene_id; 在自定义菜单中，与自定义菜单接口中KEY值对应
        public string Ticket { get; set; }

        //上报地理位置
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Precision { get; set; }

        //自定义菜单事件

    }
    
    public class MediaBase
    {
        public string MediaId { get; set; }
    }

    public class MediaVideo:MediaBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class MediaMusic
    {
        public string Title { get; set; }
        public string Description {get; set;}
        public string MusicUrl { get; set; }
        public string HQMusicUrl { get; set; }
        public string ThumbMediaId { get; set; }
    }

    public class Article
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PicUrl { get; set; }
        public string Url { get; set; }
    }

    //回复消息基类
    public class ResponseBaseMessage
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public string CreateTime { get; set; }
        public string MsgType { get; set; }
    }

    //回复文本消息
    public class ResponseTextMessage:ResponseBaseMessage
    {
        public string Content { get; set; }
    }

    //回复图片消息
    public class ResponseImageMessage : ResponseBaseMessage
    {
        public MediaBase Image { get; set; }
    }

    //回复语音消息
    public class ResponseVoiceMessage : ResponseBaseMessage
    {
        public MediaBase Voice { get; set; }
    }
    
    //回复视频消息
    public class ResponseVideoMessage : ResponseBaseMessage
    {
        public MediaVideo Video { get; set; }
    }

    //回复音乐消息
    public class ResponseMusicMessage : ResponseBaseMessage
    {
        public MediaMusic Music { get; set; }
    }

    //回复图文消息
    public class ResponseArticleMessage : ResponseBaseMessage
    {
        public int ArticleCount { get; set; }
        public List<Article> Articles { get; set; }
    }
}
