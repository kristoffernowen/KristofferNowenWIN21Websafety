import React from 'react'
import { useAuth0, withAuthenticationRequired } from '@auth0/auth0-react'

const Profile = () => {
    const { user, isAuthenticated } = useAuth0

    return (
        <div>
            {
                isAuthenticated && <p>{user.name} is logged in</p>
            }
            {
                !isAuthenticated && <p>Not logged in</p>
            }
        </div>
    )
}

export default Profile