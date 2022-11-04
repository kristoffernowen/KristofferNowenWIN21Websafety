import React from "react";
import "./BlogFormView.css"
import { useState} from "react";

const BlogFormView = () => {

    const [title, setTitle] = useState('');
    const [message, setMessage] = useState('');
    const [userId,setUserId] = useState('');

    const postBlog = async blogPost => {
        await fetch('https://localhost:7064/api/BlogEntities', {
            headers: {
                'content-type': 'application/json'
            },
            method: 'post',
            body: JSON.stringify(blogPost)
        })
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        let blogPost = {
            title: title,
            message: message,
            userId: userId
        }
        let data;
        postBlog(blogPost).then(r => data)
    }



    return (<div className="container">
        <form className="blog-form" onSubmit={handleSubmit}>
            <div className="input-group" >
                <label htmlFor="title" >Blog title</label>
                <input name="title" type="text" id="title" onChange={(e)=> setTitle(e.target.value)}/>
            </div>
            <div className="input-group" >
                <label htmlFor="message" >Blog message</label>
                <input name="message" type="text" id="message" onChange={(e) => setMessage(e.target.value)} />
            </div>
            <div className="input-group" >
                <label htmlFor="userId" >Blog message</label>
                <input name="userId" type="text" id="userId" onChange={(e) => setUserId(e.target.value)} />
            </div>
            <button className="submit-btn" >Send</button>


        </form>
    </div>)
}

export default BlogFormView
