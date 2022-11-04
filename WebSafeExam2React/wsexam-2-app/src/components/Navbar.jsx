import { NavLink} from "react-router-dom";
import "./Navbar.css"
import { useAuth0} from "@auth0/auth0-react";

const Navbar = () => {

    const { loginWithRedirect } = useAuth0();
    const { logout } = useAuth0();

    return (
       <div className="container">
           <nav className="navbar" >
               <NavLink to="/blogformview" >Blog form</NavLink>
               <NavLink to="/blogpostsview" >Blog posts</NavLink>
               <button onClick={() => loginWithRedirect()}>Log in</button>
               <button onClick={() => logout()}>Log out</button>
           </nav>
       </div>  )
}

export default Navbar;