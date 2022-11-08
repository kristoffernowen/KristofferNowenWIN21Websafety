import React from "react";
import "./BlogFormView.css"
import { useState } from "react";
import DOMPurify from 'dompurify';
import { useAuth0 } from "@auth0/auth0-react";


const BlogFormView = () => {

    const [title, setTitle] = useState('');
    const [message, setMessage] = useState('');
    const [userId, setUserId] = useState('');

    const { isAuthenticated } = useAuth0();

    const postBlog = async blogPost => {

       isAuthenticated ?  await fetch('https://localhost:7064/api/BlogEntities', {
        headers: {
            'content-type': 'application/json'
        },
        method: 'post',
        body: JSON.stringify(blogPost)
    }) : console.error("Not logged in")
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        let blogPost = {
            title: DOMPurify.sanitize(title, {ALLOWED_TAGS: ['b', 'i']}),
            message: DOMPurify.sanitize(message, {ALLOWED_TAGS: ['b', 'i']}),
            userId: DOMPurify.sanitize(userId, {ALLOWED_TAGS: ['b', 'i']})
        }
        let data;
        postBlog(blogPost).then(r => data)
        

    }


    return (
        <div className="container">
            {
                isAuthenticated ? <div>
                    <form className="blog-form" onSubmit={handleSubmit}>
                <div className="input-group">
                    <label htmlFor="title">Blog title</label>
                    <input name="title" type="text" id="title" onChange={(e) => setTitle(e.target.value)} />
                </div>
                <div className="input-group">
                    <label htmlFor="message">Blog message</label>
                    <input name="message" type="text" id="message" onChange={(e) => setMessage(e.target.value)} />
                </div>
                <div className="input-group">
                    <label htmlFor="userId">Blog message</label>
                    <input name="userId" type="text" id="userId" onChange={(e) => setUserId(e.target.value)} />
                </div>
                <button className="submit-btn">Send</button>


            </form>
            <p dangerouslySetInnerHTML={{__html: DOMPurify.sanitize(title, {ALLOWED_TAGS: ['b', 'i']})}}></p>
            <p dangerouslySetInnerHTML={{__html: message}}></p>
                </div> : <p>Not logged in</p>
}
            
        </div>)
}

export default BlogFormView
