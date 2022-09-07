import React, { useState } from 'react'
import { useDispatch } from 'react-redux'
import { Link, useNavigate } from 'react-router-dom'
import Logo from '../../assets/logo/logo'
import Button from '../../components/inputs/button/button'
import { post } from '../../helpers/api'
import { userAPI } from '../../helpers/endpoints'
import { openNotification } from '../../redux/reducers/notification-reducer'

function TwoFactorScene() {
	const navigate = useNavigate()
	const dispatch = useDispatch()
	const [token, setToken] = useState()    

	const checkToken = (token) => {
		const email = localStorage.getItem('email')
		const data = {
			token,
			email
		}
		post(`${userAPI}/token`, data)
			.then(response => {
				localStorage.setItem('token', response.data.data.token)
				navigate('/')
				dispatch(openNotification({
					type: 'success',
					message: 'Successfully signed in.'
				}))
			})
			.catch(() => dispatch(openNotification({
				type: 'error',
				message: 'Incorrect token.'
			})))
	}
    
	return (
		<div className='login-container'>
			<Logo size='md' />
			<div className='login-inputs'>
				<input placeholder='two factor auth token' onChange={(e) => setToken(e.target.value)}/>
			</div>
			<Button type='main' style='primary' text='Confirm' onClick={() => checkToken(token)} />
			<Link className='account-redirect' to='/registration'>Create new account</Link>
		</div>
	)
}

export default TwoFactorScene