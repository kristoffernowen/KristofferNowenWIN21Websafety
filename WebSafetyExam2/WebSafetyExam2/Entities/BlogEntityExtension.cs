using System.Web;

namespace WebSafetyExam2.Entities;

public static class BlogEntityExtension
{
    public static BlogEntity EncodeEntity(this BlogEntity entity)
    {
        entity.Title = HttpUtility.HtmlEncode(entity.Title);
        entity.Message = HttpUtility.HtmlEncode(entity.Message);
        entity.UserId = HttpUtility.HtmlEncode(entity.UserId);

        return entity;
    }



    public static BlogEntity DecodeAllowedTags(this BlogEntity encodedBlogEntity)
    {
        var allowedTags = new[] { "<b>", "</b>", "<i>", "</i>", "å", "ä", "ö", "Å", "Ä", "Ö" };

        foreach (var tag in allowedTags)
        {
            var encodedTag = HttpUtility.HtmlEncode(tag);

            encodedBlogEntity.Title = encodedBlogEntity.Title.Replace(encodedTag, tag);
            encodedBlogEntity.Message = encodedBlogEntity.Message.Replace(encodedTag, tag);
            encodedBlogEntity.UserId = encodedBlogEntity.UserId.Replace(encodedTag, tag);
        }

        return encodedBlogEntity;


        // Det var förvånansvärt svårt att hitta hur man ställer in språk för encode delen och jag är sen, så det blir en fuling med å ä ö

        // Jag provade att encoda på vägen in också, då blev jag tvungen att decoda dubbelt på vägen ut. Antagligen onödigt när jag har DOMPurify
        // i react inputen.

        // var encodedAllowedTags = new[] { "&lt;i&gt;", "&lt;/i&gt;", "&lt;b&gt;", "&lt;/b&gt;",  "&#229;", "&#228;", "&#246;", "&#197;", "&#196;","&#214;" };
        //
        // foreach (var tag in encodedAllowedTags)
        // {
        //     var twiceEncodedTag = HttpUtility.HtmlEncode(tag);
        //     var decodedTag = HttpUtility.HtmlDecode(tag);
        //
        //     encodedBlogEntity.Title = encodedBlogEntity.Title.Replace(twiceEncodedTag, decodedTag);
        //     encodedBlogEntity.Message = encodedBlogEntity.Message.Replace(twiceEncodedTag, decodedTag);
        //     encodedBlogEntity.UserId = encodedBlogEntity.UserId.Replace(twiceEncodedTag, decodedTag);
        // }
    }
}