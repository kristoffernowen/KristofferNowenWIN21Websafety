import "./Blog.css"
import DOMPurify from "dompurify";

function Blog ({ blog }) {

    const allowedTags = ['b', 'i']

    return (
        <div className="blog-card">

            <div className="blog-card-div">
            {/* <p className="blog-item"><b>Blog Title</b></p> */}
            <h3 className="blog-item" dangerouslySetInnerHTML={{__html: DOMPurify.sanitize(blog.title, {ALLOWED_TAGS: allowedTags})}}></h3>
            {/* <p className="blog-item"><b>Text</b></p> */}
            <p className="blog-item" dangerouslySetInnerHTML={{__html: DOMPurify.sanitize(blog.message, {ALLOWED_TAGS: allowedTags})}}></p>
            <span className="blog-item"><b>Posted by:</b></span>
            <span className="blog-item" dangerouslySetInnerHTML={{__html: DOMPurify.sanitize(blog.userId, {ALLOWED_TAGS: allowedTags})}}></span>
            </div>
        </div>
    )
}

export default Blog
