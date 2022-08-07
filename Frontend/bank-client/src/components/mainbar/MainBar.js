import React from 'react'
import Logo from '../../assets/logo/logo'
import Button from '../inputs/button/button'
import './mainbar.scss'

function MainBar() {
	return (<div className='nb-nav'>
		<Logo/>
		<div className='account-nav'>
			<Button text="John Doe" type='primary' icon='expand_more'/>
		</div>
	</div>)
}

export default MainBar