import React, { useState } from 'react'
import { useDispatch } from 'react-redux'
import { useNavigate } from 'react-router-dom'
import Logo from '../../assets/logo/logo'
import { ACCOUNT_SETTINGS, CHOOSE_THEME } from '../../modals/constants'
import { open } from '../../redux/reducers/modal-reducer'
import Button from '../inputs/button/button'
import styles from './main-bar.module.scss'
import { getFirstName, getLastName } from './selectors'

function MainBar() {
	const navigate = useNavigate()
	const dispatch = useDispatch()
	const [isExpanded, setIsExpanded] = useState(false)

	const firstName = getFirstName()
	const lastName = getLastName()

	const theme = localStorage.getItem('theme')

	const getThemeIcon = () => {
		switch (theme) {
		case 'dark':
			return 'brightness_3'
		case 'light':
			return 'brightness_5'	
		default:
			return 'brightness_4'
		}
	}

	const goToMainSite = () => {
		navigate('/')
	}

	const logout = () => {
		localStorage.removeItem('token')
		localStorage.removeItem('r')
		location.reload()
	}

	const openThemePicker = () => {
		dispatch(open({
			type: CHOOSE_THEME
		}))
		setIsExpanded(false)
	}

	const openAccountSettings = () => {
		dispatch(open({
			type: ACCOUNT_SETTINGS
		}))
	}

	const toggleMenu = () => {
		setIsExpanded(!isExpanded)
	}

	const themeIcon = getThemeIcon()

	return (<div className={styles['nb-nav']}>
		<span onClick={goToMainSite}>
			<Logo />
		</span>
		<div className={styles['account-nav']}>
			<Button text={`${firstName} ${lastName}`} type='general' buttonStyle='primary' onClick={toggleMenu} icon={!isExpanded ? 'expand_more' : 'expand_less'} />
			{isExpanded ? <ul className={styles['menu-container']}>
				<li><Button type='main' icon={'assignment_ind'} buttonStyle='accent' text='Account' onClick={openAccountSettings}/></li>
				<li><Button type='main'icon={themeIcon} buttonStyle='accent' text='Theme' onClick={openThemePicker}/></li>
				<li><Button type='main' icon={'logout'} buttonStyle='accent' text='Logout' onClick={logout}/></li>
			</ul> : null}
		</div>
	</div>)
}

export default MainBar