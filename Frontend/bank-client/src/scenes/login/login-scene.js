import axios from 'axios'
import React from 'react'
import { Link } from 'react-router-dom'
import Logo from '../../assets/logo/logo'
import Button from '../../components/inputs/button/button'
import { userAPI } from '../../helpers/endpoints'
import './login-scene.scss'

function LoginScene() {

	const signInButton = () => {
		axios.post(userAPI).then()
	}

	return(
		<div className='login-container'>
			<Logo size='md'/>
			<div className='login-inputs'>
				<input placeholder='account number'/>
				<input placeholder='password'/>
			</div>
			<Button type='main' style='primary' text='Sign in' onClick={signInButton}/>
			<Link className='account-redirect' to='/registration'>Create new account</Link>
		</div>
	)
}

export default LoginScene