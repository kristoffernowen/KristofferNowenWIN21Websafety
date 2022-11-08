import "./Blog.css"
import DOMPurify from "dompurify";

function Blog ({ blog }) {

    const allowedTags = ['b', 'i']

    return (
        <div className="blog-card">

            <p className="blog-item"><b>Title</b></p>
            <p className="blog-item" dangerouslySetInnerHTML={{__html: DOMPurify.sanitize(blog.title, {ALLOWED_TAGS: ['b', 'i']})}}></p>
            <p className="blog-item"><b>Message</b></p>
            <p className="blog-item" dangerouslySetInnerHTML={{__html: DOMPurify.sanitize(blog.message, {ALLOWED_TAGS: ['b', 'i']})}}></p>
        </div>
    )
}

export default Blog
