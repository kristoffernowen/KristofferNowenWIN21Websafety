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
        var allowedTags = new[] { "<b>", "</b>", "<i>", "</i>" };

        foreach (var tag in allowedTags)
        {
            var encodedTag = HttpUtility.HtmlEncode(tag);

            encodedBlogEntity.Title = encodedBlogEntity.Title.Replace(encodedTag, tag);
            encodedBlogEntity.Message = encodedBlogEntity.Message.Replace(encodedTag, tag);
            encodedBlogEntity.UserId = encodedBlogEntity.UserId.Replace(encodedTag, tag);
        }

        return encodedBlogEntity;
    }
}