import "./BlogPosts.css"
import Blog from "./Blog";

const BlogPosts = ({blogPosts}) => {

    return (
        <div className="blogposts-grid">
            {
                blogPosts && blogPosts.map(blog => (
                    <Blog key={blog.id} blog={blog} />
                ))
            }
        </div>)
}

export default BlogPosts
