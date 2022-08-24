import axios from 'axios'
import React, { useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import Logo from '../../assets/logo/logo'
import Button from '../../components/inputs/button/button'
import { userAPI } from '../../helpers/endpoints'
import './login-scene.scss'

function LoginScene() {
	const navigate = useNavigate()
	const [accountNumber, setAccountNumber] = useState()
	const [password, setPassword] = useState()

	const signInButton = () => {
		const data = {
			accountNumber,
			password
		}
		axios.post(userAPI,data)
			.then(() => 
				navigate('/')
			)
			.catch(() => navigate('/'))
	}

	return(
		<div className='login-container'>
			<Logo size='md'/>
			<div className='login-inputs'>
				<input placeholder='account number' onChange={(e) => setAccountNumber(e.value)}/>
				<input placeholder='password' onChange={(e) => setPassword(e.value)}/>
			</div>
			<Button type='main' style='primary' text='Sign in' onClick={signInButton}/>
			<Link className='account-redirect' to='/registration'>Create new account</Link>
		</div>
	)
}

export default LoginScene