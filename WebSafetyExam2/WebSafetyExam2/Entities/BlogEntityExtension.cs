using System.Web;

namespace WebSafetyExam2.Entities;

public static class BlogEntityExtension
{
    public static BlogEntity EncodeEntity(this BlogEntity entity)
    {
        entity.Title = HttpUtility.HtmlEncode(entity.Title);
        entity.Message = HttpUtility.HtmlEncode(entity.Message);
        entity.UserId = HttpUtility.HtmlEncode(entity.UserId);

        // return entity.DecodeAllowedTags();

        return entity;
    }



    public static BlogEntity DecodeAllowedTags(this BlogEntity encodedBlogEntity)
    {
        // Jag provade att encoda på vägen in också, då blev jag tvungen att decoda dubbelt på vägen ut. Antagligen onödigt när jag har DOMPurify
        // i react inputen, men jag tror det får vara med den här gången.

        var allowedTags = new[] { "<b>", "</b>", "<i>", "</i>" };

        foreach (var tag in allowedTags)
        {
            var encodedTag = HttpUtility.HtmlEncode(tag);

            encodedBlogEntity.Title = encodedBlogEntity.Title.Replace(encodedTag, tag);
            encodedBlogEntity.Message = encodedBlogEntity.Message.Replace(encodedTag, tag);
            encodedBlogEntity.UserId = encodedBlogEntity.UserId.Replace(encodedTag, tag);
        }

        var encodedAllowedTags = new[] { "&lt;i&gt;", "&lt;/i&gt;", "&lt;b&gt;", "&lt;/b&gt;" };

        foreach (var tag in encodedAllowedTags)
        {
            var twiceEncodedTag = HttpUtility.HtmlEncode(tag);
            var decodedTag = HttpUtility.HtmlDecode(tag);

            encodedBlogEntity.Title = encodedBlogEntity.Title.Replace(twiceEncodedTag, decodedTag);
            encodedBlogEntity.Message = encodedBlogEntity.Message.Replace(twiceEncodedTag, decodedTag);
            encodedBlogEntity.UserId = encodedBlogEntity.UserId.Replace(twiceEncodedTag, decodedTag);
        }

        return encodedBlogEntity;
    }
}