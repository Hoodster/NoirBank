import React from 'react'
import Logo from '../../assets/logo/logo'
import Button from '../inputs/button/button'
import './main-bar.scss'

function MainBar() {
	return (<div className='nb-nav'>
		<Logo/>
		<div className='account-nav'>
			<Button text="John Doe" type='general' style='primary' icon='expand_more'/>
		</div>
	</div>)
}

export default MainBar