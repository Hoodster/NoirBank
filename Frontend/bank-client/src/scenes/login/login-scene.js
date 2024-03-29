import React, { useState } from 'react'
import { useDispatch } from 'react-redux'
import { Link, useNavigate } from 'react-router-dom'
import Logo from '../../assets/logo/logo'
import Button from '../../components/inputs/button/button'
import { post } from '../../helpers/api'
import { userAPI } from '../../helpers/endpoints'
import { openNotification } from '../../redux/reducers/notification-reducer'
import styles from './login-scene.module.scss'

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
		post(`${userAPI}/signin`, data, true)
			.then(response => {
				localStorage.setItem('email', response.data.data.email)
				navigate('/token')
			}
			)
			.catch(() => dispatch(openNotification({
				type: 'error',
				message: 'Login has failed. Try again.'
			})))
	}

	return (
		<div className={styles['login-container']}>
			<Logo size='md' />
			<div className={styles['login-inputs']}>
				<input placeholder='account number' onChange={(e) => setAccountNumber(e.target.value)} />
				<input placeholder='password' type='password' onChange={(e) => setPassword(e.target.value)} />
			</div>
			<Button type='main' buttonStyle='primary' text='Sign in' onClick={signInButton} />
			<Link className={styles['account-redirect']} to='/registration'>Create new account</Link>
		</div>
	)
}

export default LoginScene