import React from 'react'
import { Navigate } from 'react-router'

function AuthorizedRoute({ children }) {
	const isAuthorized = localStorage.getItem('token')
	console.log(isAuthorized)
	return isAuthorized ? children : <Navigate to='/login' />
}

export default AuthorizedRoute