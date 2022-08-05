import React from 'react'
import Logo from '../../assets/logo/logo'
import './mainbar.scss'

function MainBar() {
	return (<div className='nb-nav'>
		<Logo/>
		<div>
			<span>Sample Name</span>
			<span>^</span>
		</div>
	</div>)
}

export default MainBar