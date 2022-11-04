using System.Web;

namespace WebSafeExam1.Entities;

public static class BlogEntityExtension
{
    public static BlogEntity EncodeEntity(this BlogEntity entity)
    {
        entity.Title = HttpUtility.HtmlEncode(entity.Title);

        return entity.DecodeAllowedTags();
    }

    

    public static BlogEntity DecodeAllowedTags(this BlogEntity entity)
    {
        var allowedTags = new[] {"<b>", "</b>", "<i>", "</i>" };

        foreach (var tag in allowedTags)
        {
            var encodedTag = HttpUtility.HtmlEncode(tag);

            entity.Title = entity.Title.Replace(encodedTag, tag);
        }

        return entity;
    }
}
