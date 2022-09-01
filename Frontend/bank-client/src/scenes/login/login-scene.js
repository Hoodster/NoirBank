import axios from 'axios'
import React, { useState } from 'react'
import { useDispatch } from 'react-redux'
import { Link, useNavigate } from 'react-router-dom'
import Logo from '../../assets/logo/logo'
import Button from '../../components/inputs/button/button'
import { userAPI } from '../../helpers/endpoints'
import { openNotification } from '../../redux/reducers/notification-reducer'
import './login-scene.scss'

function LoginScene() {
	const navigate = useNavigate()
	const dispatch = useDispatch()
	const [accountNumber, setAccountNumber] = useState('')
	const [password, setPassword] = useState('')

	const signInButton = () => {
		const data = {
			accountNumber,
			password
		}
		axios.post(`${userAPI}/signin`, data)
			.then(response => {
				localStorage.setItem('token', response.data.data.token)
				navigate('/')
				dispatch(openNotification({
					type: 'success',
					message: 'Successfully signed in.'
				}))
			}
			)
			.catch(() => dispatch(openNotification({
				type: 'error',
				message: 'Login has failed. Try again.'
			})))
	}

	return (
		<div className='login-container'>
			<Logo size='md' />
			<div className='login-inputs'>
				<input placeholder='account number' onChange={(e) => setAccountNumber(e.target.value)} />
				<input placeholder='password' type='password' onChange={(e) => setPassword(e.target.value)} />
			</div>
			<Button type='main' style='primary' text='Sign in' onClick={signInButton} />
			<Link className='account-redirect' to='/registration'>Create new account</Link>
		</div>
	)
}

export default LoginScene