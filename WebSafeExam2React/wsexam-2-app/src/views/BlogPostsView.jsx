import {useEffect, useState} from "react";
import BlogPosts from "../components/BlogPosts";
import './BlogPostsView.css'

const BlogPostsView = () => {

    const [blogPosts, setBlogPosts] = useState([]);

    useEffect(() => {

        async function fetchData() {
            const res = await fetch('https://localhost:7064/api/BlogEntities', {
                    method: 'GET',
                    headers: {
                        'content-type': 'application/json',
                    }
                }
            )
            const json = await res.json();
            setBlogPosts(json);
        }

        fetchData();
    }, [])

    return (
        <div>
            <h1>Blog posts</h1>
            <BlogPosts blogPosts={blogPosts}/>
        </div>
    )
}

export default BlogPostsView
