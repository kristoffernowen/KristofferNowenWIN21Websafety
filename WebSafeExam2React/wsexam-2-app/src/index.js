import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import { BrowserRouter } from "react-router-dom";
import { Auth0Provider } from "@auth0/auth0-react";


const root = ReactDOM.createRoot(document.getElementById('root'));

//
const domain = process.env.REACT_APP_AUTH0_DOMAIN;
const clientId = process.env.REACT_APP_AUTH0_CLIENT_ID;
//

root.render(
    /*  <BrowserRouter>
         <React.StrictMode>
             <Auth0Provider domain="dev-bz6ufpqwlzmwscqe.us.auth0.com" clientId="hp41m3h1jvUS73WRU8keXWtUQq98kqGl" redirectUri={window.location.origin}>
                 <App />
             </Auth0Provider>
         </React.StrictMode>
     </BrowserRouter> */ 
    <BrowserRouter>
        <React.StrictMode>
            <Auth0Provider domain={domain} clientId={clientId} redirectUri={window.location.origin}>
                <App />
            </Auth0Provider>
        </React.StrictMode>
    </BrowserRouter>
);

