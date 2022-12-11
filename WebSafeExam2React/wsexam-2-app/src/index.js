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
const audience = process.env.REACT_APP_AUTH0_AUDIENCE;
//

root.render(
      /*<BrowserRouter>
         <React.StrictMode>
             <Auth0WithHistory>             Jag hann inte få det att funka
                 <App />
             </Auth0WithHistory>
         </React.StrictMode>
     </BrowserRouter>*/
    <BrowserRouter>
        <React.StrictMode>
            <Auth0Provider domain={domain} clientId={clientId} redirectUri={window.location.origin}
                           audience={audience} scope="create:blogEntity">
                <App />
            </Auth0Provider>
        </React.StrictMode>
    </BrowserRouter>
);

