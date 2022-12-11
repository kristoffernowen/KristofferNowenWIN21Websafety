import React from "react";
import "./BlogFormView.css"
import { useState, useEffect } from "react";
import DOMPurify from 'dompurify';
import { useAuth0 } from "@auth0/auth0-react";

const BlogFormView = () => {

    const [title, setTitle] = useState('');
    const [message, setMessage] = useState('');
    const { user, isAuthenticated, getAccessTokenSilently } = useAuth0();

    useEffect(() => {
        const getToken = async () => {
            if (isAuthenticated) {
                try {
                    const token = await getAccessTokenSilently({
                        audience: process.env.REACT_APP_AUTH0_AUDIENCE
                    })

                    localStorage.setItem('accessToken', token)
                } catch {

                }
            } else {
                localStorage.removeItem('accessToken')
            }
        }

        getToken();

    }, [getAccessTokenSilently, isAuthenticated])

    const token = localStorage.getItem('accessToken')

    const postBlog = async blogPost => {

        isAuthenticated ? await fetch('https://localhost:7064/api/BlogEntities', {
            headers: {
                'content-type': 'application/json',
                'authorization': `Bearer ${token}`
            },
            method: 'post',
            body: JSON.stringify(blogPost)
        }) : console.error("Not logged in")
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        let blogPost = {
            title: DOMPurify.sanitize(title, { ALLOWED_TAGS: ['b', 'i'] }),
            message: DOMPurify.sanitize(message, { ALLOWED_TAGS: ['b', 'i'] }),
            userId: user.name
        }
        let data;
        postBlog(blogPost).then(r => data)
        document.querySelector('#blogForm').reset();
    }

    return (
        <div className="container">
            {
                isAuthenticated ?
                    <div className="outside-border-div">
                        <form id="blogForm" className="blog-form" onSubmit={handleSubmit}>
                            <div className="input-group">
                                <label htmlFor="title">Blog title</label>
                                <input name="title" type="text" id="title" onChange={(e) => setTitle(e.target.value)} />
                            </div>
                            <div className="input-group">
                                <label htmlFor="message">Blog message</label>
                                <input name="message" type="text" id="message" onChange={(e) => setMessage(e.target.value)} />
                            </div>
                            <button className="submit-btn">Send</button>
                        </form>
                    </div>
                    :
                    <div className="outside-border-div">
                        <div className="inside-border-div">
                            <h2>
                                Log in to write a blog post
                            </h2>
                        </div>
                    </div>
            }
        </div>)
}

export default BlogFormView
