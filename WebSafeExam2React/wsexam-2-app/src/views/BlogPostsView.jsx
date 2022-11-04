import {useEffect, useState} from "react";


const BlogPostsView = () => {

    const [ blogPosts, setBlogPosts] = useState([]);

    useEffect(() => {
        async function fetchData() {
            const res = await fetch('https://localhost:7064/api/BlogEntities')
            const json = await res.json();
            setBlogPosts(json);
        }
        fetchData();
    }, [])

    console.log(blogPosts)

    return (
        <div>
            <p>Blog posts view</p>

        </div>
    )
}

export default BlogPostsView
