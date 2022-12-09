import { NavLink } from "react-router-dom";
import "./Navbar.css"
import { useAuth0 } from "@auth0/auth0-react";

const Navbar = () => {

    const { loginWithRedirect } = useAuth0();
    const { logout } = useAuth0();
    const { isAuthenticated } = useAuth0();
    const { user } = useAuth0();

    return (
        <div className="container">
            <div className="container-middle">
                <div className="container-div">
                    <div>
                        <h2>The New Blogger Dogger</h2>
                    </div>
                    <nav className="navbar" >
                        <div className="navbar-side">
                            <NavLink className="navlink" to="/blogformview" >Write a blog post</NavLink>
                            <NavLink className="navlink" to="/" >Read all the blog posts</NavLink>
                        </div>
                        <div className="navbar-log">

                            {
                                isAuthenticated && <div className="navbar-log">
                                    <p>{user.name} is logged in</p><button onClick={() => logout()}>Log out</button>
                                </div>
                            }
                            {
                                !isAuthenticated && <button onClick={() => loginWithRedirect()}>Log in</button>
                            }

                        </div>
                    </nav>
                </div>
            </div>
        </div>)
}

export default Navbar;
