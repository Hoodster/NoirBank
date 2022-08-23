import React from 'react'
import { useNavigate } from 'react-router-dom'
import Logo from '../../assets/logo/logo'
import Button from '../inputs/button/button'
import './main-bar.scss'

function MainBar() {
	const navigate = useNavigate()

	const goToMainSite = () => {
		navigate('/')
	}

	return (<div className='nb-nav'>
		<span onClick={goToMainSite}>
			<Logo/>
		</span>
		<div className='account-nav'>
			<Button text="John Doe" type='general' style='primary' icon='expand_more'/>
		</div>
	</div>)
}

export default MainBar